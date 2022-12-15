using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryBrandSupplier : RepositoryBase<BrandSupplier>, IRepositoryBrandSupplier
    {
        public RepositoryBrandSupplier(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<BrandSupplier>> GetAllAsync()
        {

            var include = tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
                .Include(x => x.Brand)
                .Include(x => x.Supplier);

            var result = await include.ToListAsync();
            return result;
        }

      
    }
}
