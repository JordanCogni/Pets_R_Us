using Pets_R_Us.Contracts;
using Pets_R_Us.Data;

namespace Pets_R_Us.Repositories
{
    public class PlayDateRespository : GenericRepository<PlayDate>, IPlayDateRepository
    {
        public PlayDateRespository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
