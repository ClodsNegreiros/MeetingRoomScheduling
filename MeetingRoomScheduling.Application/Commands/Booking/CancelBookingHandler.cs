using MediatR;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CancelBookingHandler : IRequestHandler<CancelBookingCommand, Domain.Entities.Booking>
    {
        private readonly IBookingRepository _repository;
        
        public CancelBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Booking> Handle(CancelBookingCommand command, CancellationToken cancellationToken)
        {
            var existingBooking = _repository.GetById(command.Id);
            if (existingBooking == null)
            {
                throw new KeyNotFoundException($"Reserva com Id {command.Id} não encontrado.");
            }

            var room = ToUpdate(existingBooking.Result);
            return await _repository.UpdateAsync(room);
        }

        private Domain.Entities.Booking ToUpdate(Domain.Entities.Booking booking)
        {
            booking.Status = Domain.Enums.EBookingStatus.Canceled;

            return booking;
        }
    }
}
