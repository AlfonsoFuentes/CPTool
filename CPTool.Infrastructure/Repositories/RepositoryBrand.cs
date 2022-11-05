using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryBrand : RepositoryBase<Brand>, IRepositoryBrand
    {
        public RepositoryBrand(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Brand>> GetAllAsync()
        {
            var result = await dbcontext!.Brands!
                .Include(x => x.BrandSuppliers).ThenInclude(x => x.Supplier)
                .Include(x => x.BrandSuppliers).ThenInclude(x => x.Supplier).ThenInclude(x => x.TaxCodeLD)
                .Include(x => x.BrandSuppliers).ThenInclude(x => x.Supplier).ThenInclude(x => x.TaxCodeLP)

                .ToListAsync();
            return result;
        }

        public override async Task<Brand> GetByIdAsync(int id)
        {
            var result = await dbcontext!.Brands!
               .Include(x => x.BrandSuppliers).ThenInclude(x => x.Supplier)
               .Include(x => x.BrandSuppliers).ThenInclude(x => x.Supplier).ThenInclude(x => x.TaxCodeLD)
                .Include(x => x.BrandSuppliers).ThenInclude(x => x.Supplier).ThenInclude(x => x.TaxCodeLP)
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
