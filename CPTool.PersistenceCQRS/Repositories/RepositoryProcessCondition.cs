

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryProcessCondition : CommandRepository<ProcessCondition>, IRepositoryProcessCondition
    {
        public RepositoryProcessCondition(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
