using MediatR;
using MeetingRoomScheduling.Application.Commands.User;
using MeetingRoomScheduling.Application.Interfaces;
using MeetingRoomScheduling.Application.Requests;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.User
{
    public class CreateUserUseCase : BaseUseCase, ICreateUserUseCase
    {
        public CreateUserUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<Domain.Entities.User> Execute(CreateUserRequest request)
        {
            return await mediator.Send(new CreateUserCommand(request));
        }
    }
}
