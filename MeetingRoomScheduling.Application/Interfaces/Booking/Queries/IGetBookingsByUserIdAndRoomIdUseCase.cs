using MeetingRoomScheduling.Application.Requests.Booking;
using MeetingRoomScheduling.Domain.Entities;

public interface IGetBookingsByUserIdAndRoomIdUseCase
{
    Task<List<Booking>> Execute(GetBookingsByUserIdAndRoomIdRequest request);
}