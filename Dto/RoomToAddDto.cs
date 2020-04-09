using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShinyBooking.Models;

namespace ShinyBooking.Dto
{
    public class RoomToAddDto
    {

        public RoomToAddDto()
        {
           
        }
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string RoomArrangementsCapabilitiesDescription { get; set; }
        
        public double Price { get; set; }

        public int Area { get; set; }
        
        public int Capacity { get; set; }

        public bool ParkingSpace { get; set; }
        
        public IList<Photo> Photos { get; set; }

        public IList<RoomEquipment> RoomEquipments { get; set; }

        public IList<RoomAmenitiesForDisabled> RoomAmenitiesForDisabled { get; set; }

        public IList<RoomActivities> RoomActivities { get; set; }
        
        public RoomAddress RoomAddress { get; set; }

    }
}
