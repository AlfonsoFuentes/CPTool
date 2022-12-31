

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositorySignal : CommandRepository<Signal>, IRepositorySignal
    {
        public RepositorySignal(TableContext dbcontext) : base(dbcontext)
        {
        }
       
     
    }
}
