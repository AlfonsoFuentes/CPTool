namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryTaxesItem : CommandRepository<TaxesItem>, IRepositoryTaxesItem
    {
        public RepositoryTaxesItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
