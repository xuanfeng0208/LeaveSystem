using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;
using LeaveSystem.Domain.Models.SearchModels;
using Microsoft.AspNetCore.Mvc;

namespace LeaveSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IRoleService _roleService;

        public RoleController(
            IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var role = _roleService.GetByID(id.Value);
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpGet]
        public IActionResult Get(RoleSearchModel searchModel)
        {
            if (searchModel == null)
                searchModel = new();

            var list = _roleService.GetList(searchModel);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _roleService.CreateAsync(model);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] RoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _roleService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            await _roleService.DeleteAsync(id.Value);

            return Ok();
        }
    }
}