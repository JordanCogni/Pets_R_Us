using System.ComponentModel.DataAnnotations;

namespace Pets_R_Us.Models
{
    public class PlayDateWithUsers
    {
        public int Id { get; set; }
        [Display(Name = "A Title For Your Playdate")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Date Of The Playdate")]
        [Required]
        public DateTime RequestDate { get; set; }
        public bool Attending { get; set; }
        public string ReceivingUserId { get; set; }
        public string Users { get; set; }
        public string PetBreed { get; set; }

    }
}
