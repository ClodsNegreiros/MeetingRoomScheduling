using MediatR;
using MeetingRoomScheduling.Application.Requests;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = ToModel(command.Request);
            return await _repository.CreateAsync(user);
        }

        private Domain.Entities.User ToModel(CreateUserRequest request)
        {
            return new Domain.Entities.User(request.Name, request.Email, request.Password);
        }
    }
}
