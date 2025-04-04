﻿using MediatR;
using MeetingRoomScheduling.Application.Commands.Booking;
using MeetingRoomScheduling.Application.Interfaces.Booking;
using Tourmine.Tournament.Application.UseCases;

namespace MeetingRoomScheduling.Application.UseCases.Booking
{
    public class CancelBookingUseCase : BaseUseCase, ICancelBookingUseCase
    {
        public CancelBookingUseCase(IMediator mediator) : base(mediator)
        {}

        public async Task<Domain.Entities.Booking> Execute(int id)
        {
            return await mediator.Send(new CancelBookingCommand(id));
        }
    }
}
