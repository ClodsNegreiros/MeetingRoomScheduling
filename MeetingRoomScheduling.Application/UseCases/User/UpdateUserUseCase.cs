using MediatR;
using MeetingRoomScheduling.Application.Commands.User;
using MeetingRoomScheduling.Application.Interfaces;
using MeetingRoomScheduling.Application.Requests;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.User
{
    public class UpdateUserUseCase : BaseUseCase, IUpdateUserUseCase
    {
        public UpdateUserUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<Domain.Entities.User> Execute(int id, UpdateUserRequest request)
        {
            return await mediator.Send(new UpdateUserCommand(id, request));
        }
    }
}
