using MediatR;
using MeetingRoomScheduling.Application.Commands.Room;
using MeetingRoomScheduling.Application.Interfaces.Room;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.Room
{
    public class DeleteRoomUseCase : BaseUseCase, IDeleteRoomUseCase
    {
        public DeleteRoomUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<bool> Execute(int id)
        {
            return await mediator.Send(new DeleteRoomCommand(id));
        }
    }
}
