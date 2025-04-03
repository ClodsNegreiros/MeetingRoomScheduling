using MeetingRoomScheduling.Application.Requests.User;
using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Application.Interfaces
{
    public interface ICreateUserUseCase
    {
        Task<User> Execute(CreateUserRequest request);
    }
}
