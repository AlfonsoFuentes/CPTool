using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryPurchaseOrderItem : RepositoryBase<PurchaseOrderItem>, IRepositoryPurchaseOrderItem
    {
        public RepositoryPurchaseOrderItem(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<PurchaseOrderItem>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .Include(x => x.PurchaseOrder)
                .Include(x => x.PurchaseOrder).ThenInclude(x => x!.pBrand)
                 .Include(x => x.PurchaseOrder).ThenInclude(x => x!.pSupplier)
                .Include(x => x.MWOItem)
                .ToListAsync();
            return result;
        }
        public override async Task<PurchaseOrderItem> GetByIdAsync(int id)
        {



            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .Include(x => x.PurchaseOrder)
                 .Include(x => x.PurchaseOrder).ThenInclude(x => x!.pBrand)
                 .Include(x => x.PurchaseOrder).ThenInclude(x => x!.pSupplier)
                .Include(x => x.MWOItem)
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
