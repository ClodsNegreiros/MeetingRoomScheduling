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
            var room = ToModel(command.Request);
            return await _repository.CreateAsync(room);
        }

        private Domain.Entities.Booking ToModel(CreateBookingRequest request)
        {
            return new Domain.Entities.Booking(request.RoomId, request.UserId, request.BookingStartDate, request.BookingEndDate, request.Status);
        }
    }
}
