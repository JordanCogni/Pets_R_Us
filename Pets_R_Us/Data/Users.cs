using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets_R_Us.Data
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }



        public string PetName { get; set; }

        public string PetBreed { get; set; }

        public int PetAge { get; set; }

        public string PetGender { get; set; }

        [ForeignKey("PetImageTableId")]
        public PetImageTable? PetImageTable { get; set; }

    }
}
