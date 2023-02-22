using System.ComponentModel.DataAnnotations.Schema;

namespace Pets_R_Us.Data
{
    public class PlayDate : BaseEntity
    {
        public string Title { get; set; }

        public DateTime RequestDate { get; set; }

        public bool? Attending { get; set; }

        public string RequestingUserId { get; set; }

        [ForeignKey("UserId")]
        public Users Users { get; set; }
    }
}
