using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ShinyBooking.Models
{
    public class Room
    {
        public int Id { get; set; }\\test
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int OwnerId { get; set; }
        public List<Equipment> EqList { get; set; }
        public List<Photo> Photos { get; set; }
        public string Description { get; set; }
        public Order Orders { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
    }
}