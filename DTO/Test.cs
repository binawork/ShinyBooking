using System.ComponentModel.DataAnnotations;

namespace ShinyBooking.DTO
{
    public class Test
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}