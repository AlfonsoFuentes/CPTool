

using System.Linq.Expressions;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMWOItem : CommandRepository<MWOItem>, IRepositoryMWOItem
    {
        public RepositoryMWOItem(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
              .Include(x => x.Chapter)
                .Include(x => x.UnitaryBasePrize)
                .Include(x => x.MWO)
             .Include(x => x.PurchaseOrderItems!).ThenInclude(y => y!.PurchaseOrder);

            QueryDialog = QueryDialog
                  .Include(x => x.Chapter)
                .Include(x => x.UnitaryBasePrize)
                .Include(x => x.MWO)
             .Include(x => x.PurchaseOrderItems!).ThenInclude(y => y!.PurchaseOrder);
        }
    
      

    }
}
