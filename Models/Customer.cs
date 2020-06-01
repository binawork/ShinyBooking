using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyBooking.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
       
        public string IdentityId {get; set;}
        public ApplicationUser Identity {get; set;}
        public string Location{get; set;}
        public string Locale {get; set;}
        public string Gender {get; set;}
        public IList<Room> Rooms { get; set; }
        //test

    }
}
