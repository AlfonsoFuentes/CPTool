using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositorySupplier : RepositoryBase<Supplier>, IRepositorySupplier
    {
        public RepositorySupplier(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Supplier>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
               .Include(x => x.BrandSuppliers).ThenInclude(x => x.Brand)
               .Include(x => x.TaxCodeLD)
               .Include(x => x.TaxCodeLP)
                //.Include(x => x.PurchaseOrders).ThenInclude(x => x.MWO)
               .ToListAsync();
            return result;
        }
        //public override async Task<Supplier> GetByIdAsync(int id)
        //{
        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().FindAsync(id);

        //    return result!;
        //}
    }
}
