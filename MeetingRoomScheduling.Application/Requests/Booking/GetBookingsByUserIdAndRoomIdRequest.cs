using MeetingRoomScheduling.Domain.Enums;

namespace MeetingRoomScheduling.Application.Requests.Booking
{
    public class GetBookingsByUserIdAndRoomIdRequest
    {
        public int? UserId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? BookingDate { get; set; }
        public EBookingStatus? Status { get; set; }
    }
}
