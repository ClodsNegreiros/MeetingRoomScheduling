using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Application.Interfaces
{
    public interface IDeleteUserUseCase
    {
        Task<bool> Execute(int id);
    }
}
