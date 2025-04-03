using MediatR;
using MeetingRoomScheduling.Application.Requests;

namespace MeetingRoomScheduling.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<Domain.Entities.User>
    {
        public int Id { get; set; }
        public UpdateUserRequest Request { get; set; }

        public UpdateUserCommand(int id, UpdateUserRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
