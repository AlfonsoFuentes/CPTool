

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPipeAccesory : CommandRepository<PipeAccesory>, IRepositoryPipeAccesory
    {
        public RepositoryPipeAccesory(TableContext dbcontext) : base(dbcontext)
        {
        }

      

    }
}
