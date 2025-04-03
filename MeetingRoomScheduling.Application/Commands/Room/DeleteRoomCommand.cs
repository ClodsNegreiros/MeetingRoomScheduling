using MediatR;

namespace MeetingRoomScheduling.Application.Commands.Room
{
    public class DeleteRoomCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteRoomCommand(int id)
        {
            Id = id;
        }
    }
}
