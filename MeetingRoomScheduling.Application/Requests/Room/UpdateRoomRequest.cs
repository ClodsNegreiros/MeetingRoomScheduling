namespace MeetingRoomScheduling.Application.Requests.Room
{
    public class UpdateRoomRequest
    {
        public string Name { get; set; }
        public int MaximumPeopleCapacity { get; set; }
    }
}
