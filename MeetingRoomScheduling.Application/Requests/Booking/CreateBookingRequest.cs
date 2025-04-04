namespace MeetingRoomScheduling.Application.Requests.Booking
{
    public class CreateBookingRequest
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }
        public int PeopleQuantity { get; set; }
    }
}
