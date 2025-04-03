using MediatR;
using MeetingRoomScheduling.Application.Commands.User;
using MeetingRoomScheduling.Application.Interfaces;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.User
{
    public class DeleteUserUseCase : BaseUseCase, IDeleteUserUseCase
    {
        public DeleteUserUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<bool> Execute(int id)
        {
            return await mediator.Send(new DeleteUserCommand(id));
        }
    }
}
