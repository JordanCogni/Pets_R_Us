namespace Pets_R_Us.Models
{
    public class PlayDateWithUsers
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime RequestDate { get; set; }
        public bool? Attending { get; set; }
        public string ReceivingUserId { get; set; }
        public string Users { get; set; }
        public string PetBreed { get; set; }

    }
}
