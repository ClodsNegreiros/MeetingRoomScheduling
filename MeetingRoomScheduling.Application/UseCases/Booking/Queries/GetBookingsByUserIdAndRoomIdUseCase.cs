using MediatR;
using MeetingRoomScheduling.Application.Queries.Booking;
using MeetingRoomScheduling.Application.Requests.Booking;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.Interfaces.Booking.Queries
{
    public class GetBookingsByUserIdAndRoomIdUseCase : BaseUseCase, IGetBookingsByUserIdAndRoomIdUseCase
    {
        public GetBookingsByUserIdAndRoomIdUseCase(IMediator mediator) : base(mediator)
        { }

        public async Task<List<Domain.Entities.Booking>> Execute(GetBookingsByUserIdAndRoomIdRequest request)
        {
            return await mediator.Send(new GetBookingsByUserIdAndRoomIdQuery(request));
        }
    }
}
