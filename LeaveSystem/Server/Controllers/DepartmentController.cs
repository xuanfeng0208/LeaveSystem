using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;
using Microsoft.AspNetCore.Mvc;

namespace LeaveSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        readonly IDepartmentService _departmentService;

        public DepartmentController(
            IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentService.GetByID(id.Value);
            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpGet]
        public IActionResult Get(DepartmentSearchModel searchModel)
        {
            if (searchModel == null)
                searchModel = new();

            var list = _departmentService.GetList(searchModel);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _departmentService.CreateAsync(model);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] DepartmentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _departmentService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            await _departmentService.DeleteAsync(id.Value);

            return Ok();
        }
    }
}