using MeetingRoomScheduling.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoomScheduling.Infrastructure.Mappings
{
    public class BookingMapping : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("User");
            builder.HasKey(booking => booking.Id);

            builder.Property(booking => booking.Id);
            builder.Property(booking => booking.UserId);
            builder.Property(booking => booking.RoomId);
            builder.Property(booking => booking.BookingStartDate);
            builder.Property(booking => booking.BookingEndDate);
        }
    }
}
