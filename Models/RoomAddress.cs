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

        public string Street { get; set; }

        public int BuildingNumber { get; set; }

        public int ApartmentNumber { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public Room Room { get; set; }

        public string RoomId { get; set; }
    }
}