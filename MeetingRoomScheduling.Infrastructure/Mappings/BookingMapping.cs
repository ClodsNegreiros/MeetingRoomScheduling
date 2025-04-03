using MeetingRoomScheduling.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoomScheduling.Infrastructure.Mappings
{
    public class BookingMapping : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(booking => booking.Id);

            builder.Property(booking => booking.Id);
            builder.Property(booking => booking.UserId);
            builder.Property(booking => booking.RoomId);
            builder.Property(booking => booking.BookingStartDate);
            builder.Property(booking => booking.BookingEndDate);

            builder
              .HasOne(booking => booking.User)
              .WithMany(user => user.Bookings)
              .HasForeignKey(booking => booking.UserId);

            builder
              .HasOne(booking => booking.Room)
              .WithMany(room => room.Bookings)
              .HasForeignKey(booking => booking.UserId);

        }
    }
}
