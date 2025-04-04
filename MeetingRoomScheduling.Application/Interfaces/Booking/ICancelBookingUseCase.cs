
using MeetingRoomScheduling.Application.Responses.Booking;

namespace MeetingRoomScheduling.Application.Interfaces.Booking
{
    public interface ICancelBookingUseCase
    {
        Task<BookingResponse> Execute(int id);
    }
}
