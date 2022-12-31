

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryTaxCodeLP : CommandRepository<TaxCodeLP>, IRepositoryTaxCodeLP
    {
        public RepositoryTaxCodeLP(TableContext dbcontext) : base(dbcontext)
        {
        }
        
    }
}
