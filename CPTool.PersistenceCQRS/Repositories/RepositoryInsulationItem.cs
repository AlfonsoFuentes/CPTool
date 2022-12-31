namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryInsulationItem : CommandRepository<InsulationItem>, IRepositoryInsulationItem
    {
        public RepositoryInsulationItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
