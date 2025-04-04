using MeetingRoomScheduling.Domain.Entities;

public interface IGetAllBookingUseCase
{
    Task<List<Booking>> Execute();
}