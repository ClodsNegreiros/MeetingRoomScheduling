using MediatR;
using MeetingRoomScheduling.Application.Commands.Auth;
using MeetingRoomScheduling.Application.Dtos.Auth;
using MeetingRoomScheduling.Application.Interfaces.Auth;
using MeetingRoomScheduling.Application.Requests.Auth;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.Auth
{
    public class LoginUserUseCase : BaseUseCase, ILoginUserUseCase
    {
        public LoginUserUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<UserToken> Execute(LoginUserRequest request)
        {
            return await mediator.Send(new LoginUserCommand(request));
        }
    }
}
