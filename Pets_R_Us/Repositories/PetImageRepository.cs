using Pets_R_Us.Contracts;
using Pets_R_Us.Data;

namespace Pets_R_Us.Repositories
{
    public class PetImageRepository : GenericRepository<PetImageTable>, IPetImageRepository
    {
        public PetImageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
