using MediatR;
namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CancelBookingCommand : IRequest<Domain.Entities.Booking>
    {
        public int Id { get; set; }

        public CancelBookingCommand(int id)
        {
            Id = id;
        }
    }
}
