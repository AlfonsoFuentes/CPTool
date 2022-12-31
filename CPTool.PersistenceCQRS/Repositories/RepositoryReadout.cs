

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryReadout : CommandRepository<Readout>, IRepositoryReadout
    {
        public RepositoryReadout(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
