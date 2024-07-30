using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LeaveSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        readonly IFunctionService _functionService;

        public FunctionController
            (IFunctionService functionService)
        {
            _functionService = functionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var controllerActionList = assembly.GetTypes().Where(x => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(x))
                .SelectMany(x => x.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(x => !x.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any()).Select(x => new
                {
                    Controller = x.DeclaringType?.Name,
                    Action = x.Name,
                    ReturnType = x.ReturnType.Name,
                    Attributes = x.GetCustomAttributes().Select(y => y.GetType().Name.Replace("Attribute", "")),
                }).Distinct().OrderBy(x => x.Controller).ThenBy(x => x.Action);


            var functions = controllerActionList.Where(x => !x.Attributes.Any(y => y == typeof(AllowAnonymousAttribute).Name.Replace("Attribute", ""))).Where(x => _functionService.IsExist(x.Controller, x.Action)).Select(x => new FunctionModel()
            {
                Name = $"{x.Controller?.Replace("Controller", "")}_{x.Action}",
                ControllerName = x.Controller,
                ActionName = x.Action,
            });

            foreach (var function in functions)
                _functionService.Create(function);

            var functionList = _functionService.GetList();
            return Ok(functionList);
        }
    }
}