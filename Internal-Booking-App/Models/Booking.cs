using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal_Booking_App.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        public Resource? Resource { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Please enter the name of the person booking.")]
        [StringLength(100)]
        [Display(Name = "Booked By")]
        public string BookedBy { get; set; }

        [Required]
        [StringLength (250)]
        public string Purpose { get; set; }


    }
}
