using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShinyBooking.Models
{
    public class Room
    {
        public Room()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }

        public IList<RoomEquipment> RoomEquipments { get; set; }
    }
}