using MediatR;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Queries.Booking
{
    public class GetAllBookingHandler : IRequestHandler<GetAllBookingQuery, List<Domain.Entities.Booking>>
    {
        private readonly IBookingRepository _repository;

        public GetAllBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Domain.Entities.Booking>> Handle(GetAllBookingQuery query, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
