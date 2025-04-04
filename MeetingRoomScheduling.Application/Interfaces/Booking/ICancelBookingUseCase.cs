
namespace MeetingRoomScheduling.Application.Interfaces.Booking
{
    public interface ICancelBookingUseCase
    {
        Task<Domain.Entities.Booking> Execute(int id);
    }
}
