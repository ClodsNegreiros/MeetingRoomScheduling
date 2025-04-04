using MediatR;
using MeetingRoomScheduling.Application.Requests.Booking;

namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CreateBookingCommand : IRequest<Domain.Entities.Booking>
    {
        public CreateBookingRequest Request { get; set; }

        public CreateBookingCommand(CreateBookingRequest request)
        {
            Request = request;
        }
    }
}
