using MeetingRoomScheduling.Application.Interfaces;
using MeetingRoomScheduling.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomScheduling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, [FromServices] ICreateUserUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }
    }
}
