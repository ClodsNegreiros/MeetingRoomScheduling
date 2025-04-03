using MediatR;
using MeetingRoomScheduling.Application.Requests.Room;

namespace MeetingRoomScheduling.Application.Commands.Room
{
    public class CreateRoomCommand : IRequest<Domain.Entities.Room>
    {
        public CreateRoomRequest Request { get; set; }

        public CreateRoomCommand(CreateRoomRequest request)
        {
            Request = request;
        }
    }
}
