using System.Collections.Generic;

namespace ShinyBooking.Dto
{
    public class RoomForReturnListOfRoomsDto
    {
        public RoomForReturnListOfRoomsDto()
        {
            Equipments = new List<EquipmentForReturnDto>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
        public string MainPhotoUrl { get; set; }
        public IList<EquipmentForReturnDto> Equipments { get; set; }
        public RoomAddressForReturnDto RoomAddress { get; set; }
    }
}