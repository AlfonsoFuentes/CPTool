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
            var result = await dbcontext!.Suppliers!
                .Include(x => x.BrandSuppliers).ThenInclude(x => x.Brand)

                .ToListAsync();
            return result;
        }
        public override async Task<Supplier> GetByIdAsync(int id)
        {
            var result = await dbcontext!.Suppliers!
               .Include(x => x.BrandSuppliers).ThenInclude(x => x.Brand)

               .FirstOrDefaultAsync(x=>x.Id==id);
            return result!;
        }
    }
}
