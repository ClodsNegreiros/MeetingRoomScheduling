using MeetingRoomScheduling.Application.Interfaces;
using MeetingRoomScheduling.Application.Requests;
using MeetingRoomScheduling.Application.Requests.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomScheduling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, [FromServices] ICreateUserUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        [HttpPut("v1/update/{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateUserRequest request, 
            [FromServices] IUpdateUserUseCase useCase)
        {
            var result = await useCase.Execute(id, request);
            return Ok(result);
        }

        [HttpDelete("v1/delete/{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id,
            [FromServices] IDeleteUserUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }
    }
}
