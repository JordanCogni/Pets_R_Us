using System.ComponentModel.DataAnnotations;


namespace Pets_R_Us.Models
{
    public class PlayDateVM
    {
        public int Id { get; set; }

        [Display(Name = "Play Date Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Play Date Time")]
        [Required]
        public DateTime RequestDate { get; set; }

        public bool Attending { get; set; }

        public string ReceivingUserId { get; set; }

        public string? Users { get; set; }
    }
}
