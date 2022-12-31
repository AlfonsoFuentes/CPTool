

using System.Linq.Expressions;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryWire : CommandRepository<Wire>, IRepositoryWire
    {
        public RepositoryWire(TableContext dbcontext) : base(dbcontext)
        {
        }

      
    }
}
