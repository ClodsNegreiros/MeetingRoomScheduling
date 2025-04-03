namespace MeetingRoomScheduling.Application.Interfaces.Room
{
    public interface IDeleteRoomUseCase
    {
        Task<bool> Execute(int id);
    }
}
