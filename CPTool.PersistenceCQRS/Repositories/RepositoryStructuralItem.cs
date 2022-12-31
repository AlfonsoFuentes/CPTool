namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryStructuralItem : CommandRepository<StructuralItem>, IRepositoryStructuralItem
    {
        public RepositoryStructuralItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
