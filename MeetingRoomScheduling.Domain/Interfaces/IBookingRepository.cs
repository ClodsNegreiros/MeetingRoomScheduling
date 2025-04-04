using MeetingRoomScheduling.Domain.Entities;

namespace MeetingRoomScheduling.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> CreateAsync(Booking booking);
        Task<List<Booking>> GetAll();
        Task<List<Booking>> GetBookingsByRoomAndDate(int roomId, DateTime startDate);
        Task<Booking> GetById(int id);
        Task<Booking> UpdateAsync(Booking booking);
    }
}
