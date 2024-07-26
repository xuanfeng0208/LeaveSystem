using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models.SearchModels;
using Microsoft.AspNetCore.Mvc;

namespace LeaveSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;

        public UserController(
            IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var user = _userService.GetByID(id.Value);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public IActionResult Get(UserSearchModel searchModel)
        {
            return Ok();
        }


    }
}
