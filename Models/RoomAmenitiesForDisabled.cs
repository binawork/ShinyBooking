namespace ShinyBooking.Models
{
    public class RoomAmenitiesForDisabled
    {
        public string AmenitiesForDisabledId { get; set; }

        public AmenitiesForDisabled AmenitiesForDisabled{ get; set; }

        public string RoomId { get; set; }

        public Room Room { get; set; }
    }
}