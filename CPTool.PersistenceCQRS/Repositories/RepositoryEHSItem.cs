namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryEHSItem : CommandRepository<EHSItem>, IRepositoryEHSItem
    {
        public RepositoryEHSItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
