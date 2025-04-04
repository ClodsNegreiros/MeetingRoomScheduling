using MediatR;
using MeetingRoomScheduling.Application.Requests.Room;

namespace MeetingRoomScheduling.Application.Commands.Room
{
    public class UpdateRoomCommand : IRequest<Domain.Entities.Room>
    {
        public int Id { get; set; }
        public UpdateRoomRequest Request { get; set; }

        public UpdateRoomCommand(int id, UpdateRoomRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
