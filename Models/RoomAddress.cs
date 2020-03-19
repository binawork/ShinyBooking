using System;
using System.ComponentModel.DataAnnotations;

namespace ShinyBooking.Models
{
    public class RoomAddress
    {
        public RoomAddress()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        
        public string Id { get; set; }

        [Required(ErrorMessage = "Street Name is Required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Building Number is Required")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "Apartment Number is Required")]
        public int ApartmentNumber { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal Code is Required")]
        public int PostalCode { get; set; }

        public Room Room { get; set; }

        public string RoomId { get; set; }

        public string Directions {get; set;}

        [Required(ErrorMessage = "Phone Number is Required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber1 {get; set;}

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber2 {get; set;}
        
        [Required(ErrorMessage = "Email Address is Required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress {get; set;}

        public string WebPage {get; set;}
    }
}