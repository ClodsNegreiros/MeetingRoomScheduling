using MediatR;
using MeetingRoomScheduling.Application.Requests.Room;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Room
{
    public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand, Domain.Entities.Room>
    {
        private readonly IRoomRepository _repository;

        public UpdateRoomHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Room> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
        {
            var existingRoom = _repository.GetById(command.Id);
            if (existingRoom == null) { 
                throw new KeyNotFoundException($"Sala com Id {command.Id} não encontrado.");
            }

            var roomToUpdate = ToUpdate(existingRoom.Result, command.Request);
            return await _repository.UpdateAsync(roomToUpdate);
        }
               

        private Domain.Entities.Room ToUpdate(Domain.Entities.Room room, UpdateRoomRequest request)
        {
            room.Name = request.Name;
            room.MaximumPeopleCapacity = request.MaximumPeopleCapacity;

            return room;
        }
    }
}
