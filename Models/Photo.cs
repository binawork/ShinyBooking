using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace ShinyBooking.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool MainPhoto { get; set; }

    }
}
