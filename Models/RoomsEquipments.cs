using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyBooking.Models
{
    public class RoomsEquipments
    {
        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
