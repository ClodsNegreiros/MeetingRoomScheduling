using MeetingRoomScheduling.Application.Requests.Room;

namespace MeetingRoomScheduling.Application.Interfaces.Room
{
    public interface ICreateRoomUseCase
    {
        Task<Domain.Entities.Room> Execute(CreateRoomRequest request);
    }
}
