
using CPToolCQRS.Infrastructure.Persistence;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryChapter : CommandRepository<Chapter>, IRepositoryChapter
    {
        public RepositoryChapter(TableContext dbcontext) : base(dbcontext)
        {
        }
        
    }
}
