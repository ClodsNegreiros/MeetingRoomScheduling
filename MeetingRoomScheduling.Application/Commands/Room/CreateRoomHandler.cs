using MediatR;
using MeetingRoomScheduling.Application.Requests.Room;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Room
{
    public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, Domain.Entities.Room>
    {
        private readonly IRoomRepository _repository;

        public CreateRoomHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Room> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
        {
            var room = ToModel(command.Request);
            return await _repository.CreateAsync(room);
        }

        private Domain.Entities.Room ToModel(CreateRoomRequest request)
        {
            return new Domain.Entities.Room(request.Name, request.MaximumPeopleCapacity);
        }
    }
}
