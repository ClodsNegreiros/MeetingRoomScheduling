using MeetingRoomScheduling.Application.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;
using MeetingRoomScheduling.Application.Interfaces.Auth;
using MeetingRoomScheduling.Application.Requests.Auth;

namespace MeetingRoomScheduling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("v1/authenticate")]
        public async Task<ActionResult<UserToken>> Login(
            [FromBody] LoginUserRequest request,
            [FromServices] ILoginUserUseCase useCase)
        {
            var result = await useCase.Execute(request); 

            return Ok(result);
        }
    }
}
