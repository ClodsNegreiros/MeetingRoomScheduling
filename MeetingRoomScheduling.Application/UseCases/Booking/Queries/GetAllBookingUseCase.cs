using MediatR;
using MeetingRoomScheduling.Application.Queries.Booking;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.Interfaces.Booking.Queries
{
    public class GetAllBookingUseCase : BaseUseCase, IGetAllBookingUseCase
    {
        public GetAllBookingUseCase(IMediator mediator) : base(mediator)
        { }

        public async Task<List<Domain.Entities.Booking>> Execute()
        {
            return await mediator.Send(new GetAllBookingQuery());
        }
    }
}
