


global using CPTool.PersistenceCQRS.Repositories;
global using CPToolCQRS.Infrastructure.Persistence;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryBrandSupplier : CommandRepository<BrandSupplier>, IRepositoryBrandSupplier
    {
      
        public RepositoryBrandSupplier(TableContext dbcontext) : base(dbcontext)
        {
            QueryList = QueryList
               .Include(x => x.Brand)
                .Include(x => x.Supplier).ThenInclude(x=>x.TaxCodeLD)
                .Include(x => x.Supplier).ThenInclude(x=>x.TaxCodeLP);
            QueryDialog = QueryDialog
               .Include(x => x.Brand)
               .Include(x => x.Supplier).ThenInclude(x => x.TaxCodeLD)
                .Include(x => x.Supplier).ThenInclude(x => x.TaxCodeLP);

        }
        

    }
}
