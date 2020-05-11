using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyBooking.Dto
{
    public class PhotoToAddDto
    {
        public PhotoToAddDto()
        {
           Id = Guid.NewGuid().ToString();
          
        }
         public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public string RoomId { get; set; }
        public bool IsMain { get; set; }
       
    }
}
