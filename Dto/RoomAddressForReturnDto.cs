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
        
        public string OtherAddressInformation { get; set; }
        public string City { get; set; }
        
        public string Country { get; set; }
        
        public int PostalCode { get; set; }
        public string Directions { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string EmailAddress { get; set; }

        public string WebPage { get; set; }


    }
}