using System.Collections.Generic;

namespace ShinyBooking.Dto
{
    public class RoomForReturnListOfRoomsDto
    {
        public RoomForReturnListOfRoomsDto()
        {
            EquipmentsForReturnListDto = new List<EquipmentForReturnDto>();
            ActivitiesForReturnDto = new List<ActivitiesForReturnDto>();
            AmenitiesForDisabledDto = new List<AmenitiesForDisabledDto>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
        public string MainPhotoUrl { get; set; }
        public IList<EquipmentForReturnDto> EquipmentsForReturnListDto { get; set; }
        public RoomAddressForReturnDto AddressForReturnDto { get; set; }
        public IList<ActivitiesForReturnDto> ActivitiesForReturnDto { get; set; }
        public IList<AmenitiesForDisabledDto> AmenitiesForDisabledDto { get; set; }
    }
}