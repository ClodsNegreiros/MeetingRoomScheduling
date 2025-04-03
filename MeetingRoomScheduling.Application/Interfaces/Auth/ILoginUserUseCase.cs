using MeetingRoomScheduling.Application.Dtos.Auth;
using MeetingRoomScheduling.Application.Requests.Auth;

namespace MeetingRoomScheduling.Application.Interfaces.Auth
{
    public interface ILoginUserUseCase
    {
        Task<UserToken> Execute(LoginUserRequest request);
    }
}
