using MediatR;
using MeetingRoomScheduling.Application.Requests.Booking;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Domain.Entities.Booking>
    {
        private readonly IBookingRepository _repository;
        
        public CreateBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.Booking> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = ToModel(command.Request);

            var conflictingdBookings = await _repository.GetBookingsByRoomAndDate(command.Request.RoomId, command.Request.BookingStartDate);
            if (conflictingdBookings.Any(conflictingBooking => (booking.BookingStartDate < conflictingBooking.BookingEndDate && booking.BookingEndDate > conflictingBooking.BookingStartDate)))
            {
                throw new InvalidOperationException("Já existe uma reserva nesse horário para a mesma sala.");
            }

            return await _repository.CreateAsync(booking);
        }

        private Domain.Entities.Booking ToModel(CreateBookingRequest request)
        {
            return new Domain.Entities.Booking(request.RoomId, request.UserId, request.BookingStartDate, request.BookingEndDate, Domain.Enums.EBookingStatus.Active);
        }
    }
}
