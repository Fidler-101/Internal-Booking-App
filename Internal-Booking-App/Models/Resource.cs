using System.ComponentModel.DataAnnotations;

namespace Internal_Booking_App.Models
{
    public class Resource
    {

        public int Id { get; set; }

        [Display(Name = "Resource Name")]
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        [Display(Name = "Capacity")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0.")]
        public int Capacity { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; } = true;

        // Navigation property: one resource can have many bookings
        public ICollection<Booking>? Bookings { get; set; }

    }
}
