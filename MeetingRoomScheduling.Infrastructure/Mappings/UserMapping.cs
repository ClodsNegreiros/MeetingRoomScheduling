using MeetingRoomScheduling.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoomScheduling.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id);
            builder.Property(user => user.Name);
            builder.Property(user => user.Email);
            builder.Property(user => user.Password);
        }
    }
}
