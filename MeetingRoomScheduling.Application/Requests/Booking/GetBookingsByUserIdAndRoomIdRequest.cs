namespace MeetingRoomScheduling.Application.Requests.Booking
{
    public class GetBookingsByUserIdAndRoomIdRequest
    {
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
    }
}
