using MeetingRoomScheduling.Application.Interfaces.Booking;
using MeetingRoomScheduling.Application.Requests.Booking;
using MeetingRoomScheduling.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomScheduling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("v1")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        [HttpGet("v1/bookings")]
        public async Task<IActionResult> GetBookings(
            [FromQuery] int? userId,
            [FromQuery] int? roomId,
            [FromQuery] DateTime? bookingDate,
            [FromQuery] EBookingStatus? status,
            [FromServices] IGetBookingsByUserIdAndRoomIdUseCase useCase
            )
        {
            var result = await useCase.Execute(new GetBookingsByUserIdAndRoomIdRequest { 
                UserId = userId, 
                RoomId = roomId,
                BookingDate = bookingDate,
                Status = status
            });
            return Ok(result);
        }

    }
}
