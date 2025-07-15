using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Users.Commands.CreateUser;
using TaskManagement.Application.Features.Users.Queries.GetUserById;

namespace TaskManagement.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        [HttpPost(ApiEndpoints.Users.CreateUser)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }
        [HttpGet(ApiEndpoints.Users.Get)]
        [Authorize]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var userDto = await Mediator.Send(query);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }
    }
}
