using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShinyBooking.Models
{
    public class Room
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Name is required", MinimumLength = 2)]
        public string Name { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Description is required", MinimumLength = 2)]
        public string Description { get; set; }

        [StringLength(255)]
        public string RoomArrangementsCapabilitiesDescription { get; set; }

       
        [Range(0, double.MaxValue, ErrorMessage = " Price must be greater than 0")]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = " Area must be greater than 0")]
        public int Area { get; set; }

       
        [Range(0, int.MaxValue, ErrorMessage = " Capacity must be greater than 0")]
        public int Capacity { get; set; }

        public bool ParkingSpace { get; set; }

        [Required]
        public IList<Photo> Photos { get; set; }

        public IList<RoomEquipment> RoomEquipments { get; set; }

        public IList<RoomAmenitiesForDisabled> RoomAmenitiesForDisabled { get; set; }

        public IList<RoomActivities> RoomActivities { get; set; }
        
        public RoomAddress RoomAddress { get; set; }

        public Customer Customer {get; set; }

        //public string? CustomerId {get; set;}

        
        
    }
}