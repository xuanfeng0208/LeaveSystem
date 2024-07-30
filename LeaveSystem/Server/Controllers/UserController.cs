using LeaveSystem.Domain.Interfaces.Services;
using LeaveSystem.Domain.Models;
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
            if (searchModel == null)
                searchModel = new();

            var list = _userService.GetList(searchModel);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userService.CreateAsync(model);

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _userService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
                return BadRequest();

            await _userService.DeleteAsync(id.Value);

            return Ok();
        }
    }
}