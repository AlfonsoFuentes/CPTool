

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryGasket : CommandRepository<Gasket>, IRepositoryGasket
    {
        public RepositoryGasket(TableContext dbcontext) : base(dbcontext)
        {
        }
      
    }
}
