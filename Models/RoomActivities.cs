namespace ShinyBooking.Models
{
    public class RoomActivities
    {
        public string ActivitiesId { get; set; }

        public Activities Activities{ get; set; }

        public string RoomId { get; set; }

        public Room Room { get; set; }
    }
}