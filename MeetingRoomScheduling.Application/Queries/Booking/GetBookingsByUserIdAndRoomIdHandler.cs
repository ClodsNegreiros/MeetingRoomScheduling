using MediatR;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Queries.Booking
{
    public class GetBookingsByUserIdAndRoomIdHandler : IRequestHandler<GetBookingsByUserIdAndRoomIdQuery, List<Domain.Entities.Booking>>
    {
        private readonly IBookingRepository _repository;

        public GetBookingsByUserIdAndRoomIdHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Booking>> Handle(GetBookingsByUserIdAndRoomIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetBookingsByUserIdAndRoomId(query.Request.UserId, query.Request.RoomId);
        }
    }
}
