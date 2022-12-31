global using CPTool.Domain.Entities;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryAlterationItem : CommandRepository<AlterationItem>, IRepositoryAlterationItem
    {
        public RepositoryAlterationItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
