using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyBooking.Models
{
    public class Photo
    {
        

        public string Id { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        public Room Room { get; set; }
        public string RoomId { get; set; }
        public bool IsMain { get; set; }

    }
}
