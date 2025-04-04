using MeetingRoomScheduling.Domain.Enums;

namespace MeetingRoomScheduling.Application.Requests.Booking
{
    public class CancelBookingRequest
    {
        public EBookingStatus Status { get; set; }
    }
}
