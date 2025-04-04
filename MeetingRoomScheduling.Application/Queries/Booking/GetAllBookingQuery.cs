using MediatR;

namespace MeetingRoomScheduling.Application.Queries.Booking
{
    public class GetAllBookingQuery : IRequest<List<Domain.Entities.Booking>>
    {
    }
}
