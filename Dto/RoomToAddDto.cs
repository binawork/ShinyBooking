using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShinyBooking.Models;
using ShinyBooking.Helpers;

namespace ShinyBooking.Dto
{
    public class RoomToAddDto
    {

        public RoomToAddDto()
        {
            Id = Guid.NewGuid().ToString();
           
        }
        public string Token {get; set;}
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string RoomArrangementsCapabilitiesDescription { get; set; }

        public double Price { get; set; }

        public int Area { get; set; }

        public int Capacity { get; set; }

        public bool ParkingSpace { get; set; }

        public IList<PhotoToAddDto> Photos { get; set; }

        public IList<RoomEquipment> RoomEquipments { get; set; }

        public IList<RoomAmenitiesForDisabled> RoomAmenitiesForDisabled { get; set; }

        public IList<RoomActivities> RoomActivities { get; set; }

        public RoomAddress RoomAddress { get; set; }

       
    }
}
