namespace MeetingRoomScheduling.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumPeopleCapacity { get; set; }
        public virtual List<Booking> Bookings { get; set; }

        public Room(string name, int maximumPeopleCapacity)
        {
            Name = name;
            MaximumPeopleCapacity = maximumPeopleCapacity;
            Bookings = new List<Booking>();
        }
    }
}
