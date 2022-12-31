namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryContingencyItem : CommandRepository<ContingencyItem>, IRepositoryContingencyItem
    {
        public RepositoryContingencyItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
