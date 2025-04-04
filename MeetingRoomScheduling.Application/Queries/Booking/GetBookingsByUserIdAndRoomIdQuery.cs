using MediatR;
using MeetingRoomScheduling.Application.Requests.Booking;

namespace MeetingRoomScheduling.Application.Queries.Booking
{
    public class GetBookingsByUserIdAndRoomIdQuery : IRequest<List<Domain.Entities.Booking>>
    {
        public GetBookingsByUserIdAndRoomIdRequest Request { get; set; }

        public GetBookingsByUserIdAndRoomIdQuery(GetBookingsByUserIdAndRoomIdRequest request)
        {
            Request = request;
        }
    }
}
