using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyBooking.Models
{
    public class Photo
    {
        public Photo()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public Room Room { get; set; }
        public string RoomId { get; set; }
        public bool IsMain { get; set; }

    }
}
