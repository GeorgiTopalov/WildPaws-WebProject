using WildPaws.Infrastructure.Data.Common;

namespace WildPaws.Infrastructure.Data.Repositories
{
    public class ApplicatioDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicatioDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}
