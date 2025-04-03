using MediatR;
using MeetingRoomScheduling.Application.Commands.Room;
using MeetingRoomScheduling.Application.Interfaces.Room;
using MeetingRoomScheduling.Application.Requests.Room;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.Room
{
    public class CreateRoomUseCase : BaseUseCase, ICreateRoomUseCase
    {
        public CreateRoomUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<Domain.Entities.Room> Execute(CreateRoomRequest request)
        {
            return await mediator.Send(new CreateRoomCommand(request));
        }
    }
}
