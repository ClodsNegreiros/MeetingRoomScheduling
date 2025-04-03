using MeetingRoomScheduling.Application.Requests;
using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Application.Interfaces
{
    public interface IUpdateUserUseCase
    {
        Task<User> Execute(int id, UpdateUserRequest request);
    }
}
