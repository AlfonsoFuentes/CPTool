

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryTaxCodeLD : CommandRepository<TaxCodeLD>, IRepositoryTaxCodeLD
    {
      
        public RepositoryTaxCodeLD(TableContext dbcontext) : base(dbcontext)
        {
        }
        
    }
}
