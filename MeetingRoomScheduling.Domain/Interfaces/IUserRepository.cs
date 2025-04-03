using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);
    }
}
