

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositorySignalModifier : CommandRepository<SignalModifier>, IRepositorySignalModifier
    {
        public RepositorySignalModifier(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
