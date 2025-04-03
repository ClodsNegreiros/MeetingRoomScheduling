using MediatR;
using MeetingRoomScheduling.Application.Requests;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _repository;

        public UpdateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = _repository.GetById(command.Id);
            if (existingUser == null) 
            {
                throw new KeyNotFoundException($"Torneio com Id {command.Id} não encontrado.");
            }

            var userToUpdate = ToUpdate(existingUser.Result, command.Request);
            return await _repository.UpdateAsync(userToUpdate);
        }

        private Domain.Entities.User ToUpdate(Domain.Entities.User user, UpdateUserRequest request)
        {
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;

            return user;
        }
    }
}
