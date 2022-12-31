namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryFoundationItem : CommandRepository<FoundationItem>, IRepositoryFoundationItem
    {
        public RepositoryFoundationItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
