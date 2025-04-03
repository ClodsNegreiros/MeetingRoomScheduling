using MediatR;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Room
{
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand, bool>
    {
        private readonly IRoomRepository _repository;

        public DeleteRoomHandler(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteRoomCommand command, CancellationToken cancellationToken)
        {
            var existingRoom = _repository.GetById(command.Id);
            if (existingRoom == null) { 
                throw new KeyNotFoundException($"Sala com Id {command.Id} não encontrado.");
            }

            return await _repository.DeleteAsync(existingRoom.Result);
        }
    }
}
