using MeetingRoomScheduling.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoomScheduling.Infrastructure.Mappings
{
    public class RoomMapping : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.HasKey(room => room.Id);

            builder.Property(room => room.Id);
            builder.Property(room => room.Name);
            builder.Property(room => room.MaximumPeopleCapacity);
        }
    }
}
