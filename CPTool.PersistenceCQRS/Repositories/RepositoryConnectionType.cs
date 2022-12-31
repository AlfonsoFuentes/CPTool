
global using CPToolCQRS.Infrastructure.Persistence;
global using Microsoft.EntityFrameworkCore;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryConnectionType : CommandRepository<ConnectionType>, IRepositoryConnectionType
    {
        public RepositoryConnectionType(TableContext dbcontext) : base(dbcontext)
        {
           
        }
        
    }
}
