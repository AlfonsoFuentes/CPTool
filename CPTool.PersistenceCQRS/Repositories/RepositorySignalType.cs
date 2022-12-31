

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositorySignalType : CommandRepository<SignalType>, IRepositorySignalType
    {
        public RepositorySignalType(TableContext dbcontext) : base(dbcontext)
        {
           
        }
       
    }
}
