using MediatR;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _repository;

        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = _repository.GetById(command.Id);
            if (existingUser == null) 
            {
                throw new KeyNotFoundException($"Usuário com Id {command.Id} não encontrado.");
            }

            return await _repository.DeleteAsync(existingUser.Result);
        }
    }
}
