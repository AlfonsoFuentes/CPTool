using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMeasuredVariable : RepositoryBase<MeasuredVariable>, IRepositoryMeasuredVariable
    {
        public RepositoryMeasuredVariable(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<MeasuredVariable>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<MeasuredVariable> GetByIdAsync(int id)
        {



             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
