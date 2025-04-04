using MediatR;
using MeetingRoomScheduling.Application.Requests.Booking;
using MeetingRoomScheduling.Application.Responses.Booking;
using MeetingRoomScheduling.Domain.Interfaces;

namespace MeetingRoomScheduling.Application.Commands.Booking
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, BookingResponse>
    {
        private readonly IBookingRepository _repository;
        private readonly IRoomRepository _roomRepository;
        
        public CreateBookingHandler(IBookingRepository repository, IRoomRepository roomRepository)
        {
            _repository = repository;
            _roomRepository = roomRepository;
        }

        public async Task<BookingResponse> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetById(command.Request.RoomId);
            if (room == null)
                throw new KeyNotFoundException("Sala não encontrada.");

            ValidatePeopleCapacity(command.Request.PeopleQuantity, room);

            var booking = ToModel(command.Request, room);

            var conflictingdBookings = await _repository.GetBookingsByRoomAndDate(command.Request.RoomId, command.Request.BookingStartDate);
            if (conflictingdBookings.Any(conflictingBooking => (booking.BookingStartDate < conflictingBooking.BookingEndDate && booking.BookingEndDate > conflictingBooking.BookingStartDate)))
            {
                throw new InvalidOperationException("Já existe uma reserva nesse horário para a mesma sala.");
            }

            var bookingCreated = await _repository.CreateAsync(booking);

            return ToResponse(bookingCreated);
        }

        private Domain.Entities.Booking ToModel(CreateBookingRequest request, Domain.Entities.Room room)
        {
            return new Domain.Entities.Booking(request.RoomId, request.UserId, request.BookingStartDate, request.BookingEndDate, Domain.Enums.EBookingStatus.Active, request.PeopleQuantity);
        }

        private void ValidatePeopleCapacity(int peopleQuantity, Domain.Entities.Room room)
        {
            if (peopleQuantity <= 0)
                throw new InvalidOperationException("A quantidade de pessoas deve ser maior que zero.");

            if (peopleQuantity > room.MaximumPeopleCapacity)
                throw new InvalidOperationException("A quantidade de pessoas excede a capacidade máxima da sala.");
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
