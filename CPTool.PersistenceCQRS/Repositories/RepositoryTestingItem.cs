namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryTestingItem : CommandRepository<TestingItem>, IRepositoryTestingItem
    {
        public RepositoryTestingItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
