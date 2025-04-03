using MeetingRoomScheduling.Domain.Enums;

namespace MeetingRoomScheduling.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }

        // TODO: ADD STATUS PROPERTY - ativa/cancelada
        public EBookingStatus Status { get; set; }
    }
}
