using MeetingRoomScheduling.Application.Interfaces.Booking;
using MeetingRoomScheduling.Application.Requests.Booking;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomScheduling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateBookingRequest request, [FromServices] ICreateBookingUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        [HttpPut("v1/cancel/{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromServices] ICancelBookingUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }
    }
}
