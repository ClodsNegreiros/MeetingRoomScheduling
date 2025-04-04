using MediatR;
using MeetingRoomScheduling.Application.Requests.Booking;
using MeetingRoomScheduling.Application.Responses.Booking;

namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CreateBookingCommand : IRequest<BookingResponse>
    {
        public CreateBookingRequest Request { get; set; }

        public CreateBookingCommand(CreateBookingRequest request)
        {
            Request = request;
        }
    }
}
