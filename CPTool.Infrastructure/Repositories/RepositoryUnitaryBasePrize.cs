using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryUnitaryBasePrize : RepositoryBase<UnitaryBasePrize>, IRepositoryUnitaryBasePrize
    {
        public RepositoryUnitaryBasePrize(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<UnitaryBasePrize>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<UnitaryBasePrize> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
