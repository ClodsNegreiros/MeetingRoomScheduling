namespace MeetingRoomScheduling.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumPeopleCapacity { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
