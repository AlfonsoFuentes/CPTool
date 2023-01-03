

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryDownPayment : CommandRepository<DownPayment>, IRepositoryDownPayment
    {
        public RepositoryDownPayment(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
              .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.MWO)
              .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.pBrand)
                 .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.pSupplier).ThenInclude(x => x!.TaxCodeLP)
                .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.pSupplier).ThenInclude(x => x!.TaxCodeLD);
            QueryDialog = QueryDialog
                .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.MWO)
                .Include(x => x!.PurchaseOrder).ThenInclude(x=>x!.pBrand)
                .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.pSupplier).ThenInclude(x => x!.TaxCodeLP)
                .Include(x => x!.PurchaseOrder).ThenInclude(x=>x!.pSupplier).ThenInclude(x=>x!.TaxCodeLD);
        }
       
    }
}
