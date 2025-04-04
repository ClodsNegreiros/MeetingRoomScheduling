using MeetingRoomScheduling.Domain.Enums;

namespace MeetingRoomScheduling.Application.Responses.Booking
{
    public class BookingResponse
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public EBookingStatus Status { get; set; }
        public int PeopleQuantity { get; set; }
    }
}
