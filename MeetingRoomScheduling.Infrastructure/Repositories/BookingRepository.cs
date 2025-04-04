﻿using MeetingRoomScheduling.Domain.Entities;
using MeetingRoomScheduling.Domain.Enums;
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

        public async Task<List<Booking>> GetBookingsByRoomAndDate(int roomId, DateTime startDate)
        {
            return await _context.Bookings
                .Where(booking =>
                    booking.RoomId == roomId &&
                    booking.BookingStartDate.Date == startDate.Date &&
                    booking.Status == Domain.Enums.EBookingStatus.Active)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsByUserIdAndRoomId(int? userId, int? roomId, DateTime? bookingDate, EBookingStatus? status)
        {
            var query = _context.Bookings.AsQueryable();

            if (userId.HasValue)
                query = query.Where(booking => booking.UserId == userId);

            if (roomId.HasValue)
                query = query.Where(booking => booking.RoomId == roomId);

            if (bookingDate.HasValue)
                query = query.Where(booking => booking.BookingStartDate.Date == bookingDate.Value.Date);

            if (status.HasValue)
                query = query.Where(booking => booking.Status == status.Value);

            return await query.ToListAsync();
        }
    }
}
