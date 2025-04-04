using MediatR;
using MeetingRoomScheduling.Application.Responses.Booking;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CancelBookingHandler : IRequestHandler<CancelBookingCommand, BookingResponse>
    {
        private readonly IBookingRepository _repository;
        
        public CancelBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookingResponse> Handle(CancelBookingCommand command, CancellationToken cancellationToken)
        {
            var existingBooking = _repository.GetById(command.Id);
            if (existingBooking == null)
            {
                throw new KeyNotFoundException($"Reserva com Id {command.Id} não encontrado.");
            }

            var room = ToUpdate(existingBooking.Result);
            var bookingUpdate = await _repository.UpdateAsync(room);

            return ToResponse(bookingUpdate);
        }

        private Domain.Entities.Booking ToUpdate(Domain.Entities.Booking booking)
        {
            booking.Status = Domain.Enums.EBookingStatus.Canceled;

            return booking;
        }

        private BookingResponse ToResponse(Domain.Entities.Booking booking)
        {
            return new BookingResponse
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                UserId = booking.UserId,
                BookingStartDate = booking.BookingStartDate,
                BookingEndDate = booking.BookingEndDate,
                Status = booking.Status,
                PeopleQuantity = booking.PeopleQuantity
            };
        }
    }
}
