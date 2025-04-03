using MeetingRoomScheduling.Application.Requests.Booking;

namespace MeetingRoomScheduling.Application.Interfaces.Booking
{
    public interface ICreateBookingUseCase
    {
        Task<Domain.Entities.Booking> Execute(CreateBookingRequest request);
    }
}
