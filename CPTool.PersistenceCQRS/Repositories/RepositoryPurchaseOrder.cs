

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPurchaseOrder : CommandRepository<PurchaseOrder>, IRepositoryPurchaseOrder
    {
        public RepositoryPurchaseOrder(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
                   .Include(x => x.pBrand!)
                    .Include(x => x.MWO!)
                   .Include(x => x.pSupplier!).ThenInclude(x => x.TaxCodeLD)
                   .Include(x => x.pSupplier!).ThenInclude(x => x.TaxCodeLP)
                   .Include(x => x.PurchaseOrderItems!).ThenInclude(x => x.MWOItem);

            QueryDialog = QueryDialog
                .Include(x => x.MWO!)
                  .Include(x => x.pBrand!)
                   .Include(x => x.pSupplier!).ThenInclude(x => x.TaxCodeLD)
                   .Include(x => x.pSupplier!).ThenInclude(x => x.TaxCodeLP)
                   .Include(x => x.PurchaseOrderItems!).ThenInclude(x => x.MWOItem).ThenInclude(x=>x!.Chapter);
        }
       
    }
}
