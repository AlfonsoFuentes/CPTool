

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPropertyPackage : CommandRepository<PropertyPackage>, IRepositoryPropertyPackage
    {
        public RepositoryPropertyPackage(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
