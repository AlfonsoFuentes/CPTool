

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryTaks : CommandRepository<Taks>, IRepositoryTaks
    {
        public RepositoryTaks(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
                .Include(x => x.MWO!)
                   .Include(x => x.MWOItem!)
                  
                   .Include(x => x.PurchaseOrder!).ThenInclude(x => x!.pBrand)
                   .Include(x => x.PurchaseOrder!).ThenInclude(x => x!.pSupplier).ThenInclude(x => x!.TaxCodeLD)
                   .Include(x => x.PurchaseOrder!).ThenInclude(x => x!.pSupplier).ThenInclude(x => x!.TaxCodeLP)
                   .Include(x => x.DownPayment!);

            QueryDialog = QueryDialog

                    .Include(x => x.MWO!)
                   .Include(x => x.MWOItem!)
                   .Include(x => x.PurchaseOrder!).ThenInclude(x => x!.pBrand)
                   .Include(x => x.PurchaseOrder!).ThenInclude(x => x!.pSupplier).ThenInclude(x => x!.TaxCodeLD)
                   .Include(x => x.PurchaseOrder!).ThenInclude(x => x!.pSupplier).ThenInclude(x => x!.TaxCodeLP)
                   .Include(x => x.DownPayment!);
        }

    }
}
