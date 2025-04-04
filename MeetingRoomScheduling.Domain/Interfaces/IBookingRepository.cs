using MeetingRoomScheduling.Domain.Entities;
using MeetingRoomScheduling.Domain.Enums;

namespace MeetingRoomScheduling.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> CreateAsync(Booking booking);
        Task<List<Booking>> GetAll();
        Task<List<Booking>> GetBookingsByRoomAndDate(int roomId, DateTime startDate);
        Task<List<Booking>> GetBookingsByUserIdAndRoomId(int? userId, int? roomId, DateTime? bookingDate, EBookingStatus? status);
        Task<Booking> GetById(int id);
        Task<Booking> UpdateAsync(Booking booking);
    }
}
