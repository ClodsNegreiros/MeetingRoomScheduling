using MediatR;
using MeetingRoomScheduling.Application.Dtos.Auth;
using MeetingRoomScheduling.Application.Utils.Auth;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Auth
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserToken>
    {
        private readonly IUserRepository _repository;
        private readonly TokenGenerator _tokenGenerator;

        public LoginUserHandler(IUserRepository repository, TokenGenerator tokenGenerator)
        {
            _repository = repository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var isAuthenticated = await _repository.AuthenticateAsync(request.Request.Email, request.Request.Password);

            if (!isAuthenticated)
                throw new UnauthorizedAccessException("Tentativa de login inválida.");

            return _tokenGenerator.GenerateToken(request.Request.Email);
        }
    }
}
