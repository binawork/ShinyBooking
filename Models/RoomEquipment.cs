﻿namespace ShinyBooking.Models
{
    public class RoomEquipment
    {
        public string EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        public string RoomId { get; set; }

        public Room Room { get; set; }
    
}
}
