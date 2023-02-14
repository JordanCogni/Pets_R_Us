namespace Pets_R_Us.Data
{
    public class PetImageTable : BaseEntity
    {
        public string PetPic { get; set; }

        public string ImageTitle { get; set; }

        public string ImageCaption { get; set; }

        public string? PetImageUrl { get; set; }
    }
}
