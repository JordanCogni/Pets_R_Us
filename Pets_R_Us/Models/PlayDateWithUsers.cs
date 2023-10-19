using System.ComponentModel.DataAnnotations;

namespace Pets_R_Us.Models
{
    public class PlayDateWithUsers
    {
        public int Id { get; set; }
        [Display(Name = "A title for your playdate")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Date of the playdate")]
        [Required]
        public DateTime RequestDate { get; set; }
        public bool Attending { get; set; }
        public string ReceivingUserId { get; set; }
        public string Users { get; set; }
        public string PetBreed { get; set; }

    }
}
