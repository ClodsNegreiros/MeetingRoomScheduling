using MeetingRoomScheduling.Application.Requests.Booking;
using MeetingRoomScheduling.Application.Responses.Booking;

namespace MeetingRoomScheduling.Application.Interfaces.Booking
{
    public interface ICreateBookingUseCase
    {
        Task<BookingResponse> Execute(CreateBookingRequest request);
    }
}
