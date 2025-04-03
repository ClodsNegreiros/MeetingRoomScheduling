using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task DeleteAsync(User user);
        Task<User> GetById(int id);
        Task<User> UpdateAsync(User user);
    }
}
