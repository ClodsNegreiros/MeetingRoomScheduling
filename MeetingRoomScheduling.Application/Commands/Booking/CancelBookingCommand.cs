using MediatR;
using MeetingRoomScheduling.Application.Responses.Booking;
namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CancelBookingCommand : IRequest<BookingResponse>
    {
        public int Id { get; set; }

        public CancelBookingCommand(int id)
        {
            Id = id;
        }
    }
}
