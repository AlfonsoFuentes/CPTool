

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryEntityUnit : CommandRepository<EntityUnit>, IRepositoryEntityUnit
    {
        public RepositoryEntityUnit(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
