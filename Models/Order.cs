using System;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;

namespace ShinyBooking.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int UserId { get; set; }
        public IdentityUser User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}