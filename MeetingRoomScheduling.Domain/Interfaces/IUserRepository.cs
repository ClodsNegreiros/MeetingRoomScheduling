using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<User> CreateAsync(User user);
        Task<bool> DeleteAsync(User user);
        Task<User> GetById(int id);
        Task<User> UpdateAsync(User user);
    }
}
