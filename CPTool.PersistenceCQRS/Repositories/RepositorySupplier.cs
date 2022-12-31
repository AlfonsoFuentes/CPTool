

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositorySupplier : CommandRepository<Supplier>, IRepositorySupplier
    {
        public RepositorySupplier(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
                .Include(x => x.TaxCodeLP!)
                   .Include(x => x.TaxCodeLD!);

            QueryDialog = QueryDialog

                   .Include(x => x.TaxCodeLP!)
                   .Include(x => x.TaxCodeLD!);
        }
       
    }
}
