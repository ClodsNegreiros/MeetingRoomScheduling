using MeetingRoomScheduling.Domain.Entities;
using MeetingRoomScheduling.Domain.Interfaces;
using MeetingRoomScheduling.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduling.Infrastructure.Repositories
{
    public class BookingRepository :  IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> GetById(int id)
        {
            return await _context.Bookings
                .Where(room => room.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Booking>> GetAll()
        {
            return await _context.Bookings.ToListAsync();
        }
    }
}
