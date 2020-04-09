using System.Collections.Generic;

namespace ShinyBooking.Dto
{
    public class RoomForReturnRoomDetailsDto
    {
        public RoomForReturnRoomDetailsDto()
        {
            Equipments = new List<EquipmentForReturnDto>();
            Activities = new List<ActivitiesForReturnDto>();
            AmenitiesForDisabled = new List<AmenitiesForDisabledDto>();
            Photos = new List<PhotosForReturnDto> ();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public string RoomArrangementsCapabilitiesDescription { get; set; }
        public double Price { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
        public bool ParkingSpace { get; set; }
        public IList<PhotosForReturnDto> Photos { get; set; }
        public IList<EquipmentForReturnDto> Equipments { get; set; }
        public RoomAddressForReturnDto RoomAddress { get; set; }
        public IList<ActivitiesForReturnDto> Activities { get; set; }
        public IList<AmenitiesForDisabledDto> AmenitiesForDisabled { get; set; }
    }
}