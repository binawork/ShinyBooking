namespace ShinyBooking.Dto
{
    public class PhotoForReturnDto
    {
        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public string RoomId { get; set; }
        public bool IsMain { get; set; }
    }
}