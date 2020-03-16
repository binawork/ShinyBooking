using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyBooking.Models
{
    public class Equipment
    {
        public Equipment()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<RoomEquipment> RoomEquipments { get; set; }
    }
}
