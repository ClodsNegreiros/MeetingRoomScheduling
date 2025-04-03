using MeetingRoomScheduling.Application.Interfaces.Room;
using MeetingRoomScheduling.Application.Requests.Room;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomScheduling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpPost("v1/create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateRoomRequest request, 
            [FromServices] ICreateRoomUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }
    }
}
