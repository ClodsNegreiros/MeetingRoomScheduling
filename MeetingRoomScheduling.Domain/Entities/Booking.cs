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
        public EBookingStatus Status { get; set; }

        public Booking(int roomId, int userId, DateTime bookingStartDate, DateTime bookingEndDate, EBookingStatus status)
        {
            ValidateBookingStartAndEndDate(bookingStartDate, bookingEndDate);

            RoomId = roomId;
            UserId = userId;
            BookingStartDate = bookingStartDate;
            BookingEndDate = bookingEndDate;
            Status = status;

        }

        public void ValidateBookingStartAndEndDate(DateTime bookingStartDate, DateTime bookingEndDate)
        {
            if (bookingStartDate.Date != bookingEndDate.Date)
            {
                throw new InvalidOperationException("A reserva deve iniciar e terminar no mesmo dia.");
            }
        }

    }
}
