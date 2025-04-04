namespace MeetingRoomScheduling.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public virtual List<Booking> Bookings { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            Bookings = new List<Booking>();
        }
    }
}
