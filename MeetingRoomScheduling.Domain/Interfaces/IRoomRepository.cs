using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> CreateAsync(Room room);
        Task<bool> DeleteAsync(Room room);
        Task<Room> GetById(int id);
        Task<Room> UpdateAsync(Room room);
    }
}
