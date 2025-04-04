namespace MeetingRoomScheduling.Application.Requests.Room
{
    public class CreateRoomRequest
    {
        public string Name { get; set; }
        public int MaximumPeopleCapacity { get; set; }
    }
}
