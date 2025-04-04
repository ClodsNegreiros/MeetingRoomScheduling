﻿using MediatR;
using MeetingRoomScheduling.Application.Requests.User;

namespace MeetingRoomScheduling.Application.Commands.User
{
    public class CreateUserCommand : IRequest<Domain.Entities.User>
    {
        public CreateUserRequest Request { get; set; }

        public CreateUserCommand(CreateUserRequest request)
        {
            Request = request;
        }
    }
}
