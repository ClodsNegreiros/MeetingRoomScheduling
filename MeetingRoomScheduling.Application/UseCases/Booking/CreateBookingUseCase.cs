using MediatR;
using MeetingRoomScheduling.Application.Commands.Booking;
using MeetingRoomScheduling.Application.Interfaces.Booking;
using MeetingRoomScheduling.Application.Requests.Booking;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.Booking
{
    public class CreateBookingUseCase : BaseUseCase, ICreateBookingUseCase
    {
        public CreateBookingUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<Domain.Entities.Booking> Execute(CreateBookingRequest request)
        {
            return await mediator.Send(new CreateBookingCommand(request));
        }
    }
}
