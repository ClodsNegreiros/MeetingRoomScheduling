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

        [HttpGet("v1/all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        [HttpGet("v1/bookings")]
        public async Task<IActionResult> GetAll(
            [FromQuery] int? userId,
            [FromQuery] int? roomId,
            [FromServices] IGetBookingsByUserIdAndRoomIdUseCase useCase
            )
        {
            var result = await useCase.Execute(new GetBookingsByUserIdAndRoomIdRequest { UserId = userId, RoomId = roomId });
            return Ok(result);
        }

    }
}
