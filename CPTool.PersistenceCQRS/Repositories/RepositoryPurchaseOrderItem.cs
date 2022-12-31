

using System.Linq.Expressions;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPurchaseOrderItem : CommandRepository<PurchaseOrderItem>, IRepositoryPurchaseOrderItem
    {
        public RepositoryPurchaseOrderItem(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
                    .Include(x => x.MWOItem!)
                   .Include(x => x.PurchaseOrder!);

            QueryDialog = QueryDialog

                   .Include(x => x.MWOItem!)
                   .Include(x => x.PurchaseOrder!);
        }
       
    }
}
