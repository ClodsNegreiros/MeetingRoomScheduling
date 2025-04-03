using MeetingRoomScheduling.Application.Requests.Room;

namespace MeetingRoomScheduling.Application.Interfaces.Room
{
    public interface IUpdateRoomUseCase
    {
        Task<Domain.Entities.Room> Execute(int id, UpdateRoomRequest request);
    }
}
