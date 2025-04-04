using MediatR;
using MeetingRoomScheduling.Application.Commands.Room;
using MeetingRoomScheduling.Application.Interfaces.Room;
using MeetingRoomScheduling.Application.Requests.Room;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.Room
{
    public class UpdateRoomUseCase : BaseUseCase, IUpdateRoomUseCase
    {
        public UpdateRoomUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<Domain.Entities.Room> Execute(int id, UpdateRoomRequest request)
        {
            return await mediator.Send(new UpdateRoomCommand(id, request));
        }
    }
}
