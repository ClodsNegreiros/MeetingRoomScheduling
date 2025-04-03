using MediatR;
using MeetingRoomScheduling.Application.Dtos.Auth;
using MeetingRoomScheduling.Application.Requests.Auth;

namespace MeetingRoomScheduling.Application.Commands.Auth
{
    public class LoginUserCommand : IRequest<UserToken>
    {
        public LoginUserRequest Request { get; set; }
        public LoginUserCommand(LoginUserRequest request)
        {
            Request = request;
        }
    }
}
