using MeetingRoomScheduling.Application.Requests;
using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Application.Interfaces
{
    public interface ICreateUserUseCase
    {
        Task<User> Execute(CreateUserRequest request);
    }
}
