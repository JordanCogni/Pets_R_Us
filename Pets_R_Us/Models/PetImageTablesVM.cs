using System.ComponentModel.DataAnnotations;

namespace Pets_R_Us.Models
{
    public class PetImageTablesVM
    {
        public int Id { get; set; }
        [Display(Name = "Picture of fur baby")]
        [Required(ErrorMessage = "Please upload a picture of your fur baby, we would love to see it")]
        public string PetPic { get; set; }


        [Display(Name = "Image title")]
        [Required]
        public string ImageTitle { get; set; }

        [Display(Name = "Image caption")]
        [Required]
        public string ImageCaption { get; set; }

        [Display(Name = "Upload your image")]
        [Required]
        public IFormFile PetImage { get; set; }

        [Display(Name = "Your pet photos")]
        public string? PetImageUrl { get; set; }
    }
}
