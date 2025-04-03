using MeetingRoomScheduling.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduling.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingMapping());
            modelBuilder.ApplyConfiguration(new RoomMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
