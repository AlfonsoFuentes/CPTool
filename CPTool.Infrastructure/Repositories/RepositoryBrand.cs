using CPTool.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryBrand : RepositoryBase<Brand>, IRepositoryBrand
    {
      
        public RepositoryBrand(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Brand>> GetAllAsync()
        {

            var include = tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
                .Include(x => x.BrandSuppliers).ThenInclude(x => x.Supplier);
          

            var result  = await include.ToListAsync();
            return result;
        }
        //public override async Task<Brand> GetByIdAsync(int id)
        //{
        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution().FindAsync(id);

        //    return result!;
        //}

    }
}
