using System.ComponentModel.DataAnnotations;
using ShinyBooking.Models;

namespace ShinyBooking.Dto
{
    public class RoomAddressForReturnDto
    {
        public string Id { get; set; }
        
        public string Street { get; set; }
        
        public int BuildingNumber { get; set; }
        
        public int ApartmentNumber { get; set; }
        
        public string City { get; set; }
        
        public string Country { get; set; }
        
        public int PostalCode { get; set; }
    }
}