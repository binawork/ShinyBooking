using System.Collections.Generic;
using ShinyBooking.Models;

namespace ShinyBooking.Dto
{
    public class RoomForReturnDetailsDto
    {

        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public double Rating { get; set; }
        
        public string Description { get; set; }
        
        public string RoomArrangementsCapabilitiesDescription { get; set; }
        
        public double Price { get; set; }
        
        public int Area { get; set; }
        
        public int Capacity { get; set; }

        public bool ParkingSpace { get; set; }

        public IList<PhotoForReturnDto> Photos { get; set; }

        public IList<EquipmentForReturnDto> Equipments { get; set; }

        public IList<AmenitiesForDisabledDto> AmenitiesForDisabled { get; set; }

        public IList<ActivitiesForReturnDto> Activities { get; set; }
       
        public RoomAddressForReturnDto RoomAddress { get; set; }
       
          public CustomerDetailsForRoomReturnDto CustomerInformation {get; set;}
    }
}