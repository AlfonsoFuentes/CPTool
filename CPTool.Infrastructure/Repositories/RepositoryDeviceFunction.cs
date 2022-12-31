using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryDeviceFunction : RepositoryBase<DeviceFunction>, IRepositoryDeviceFunction
    {
        public RepositoryDeviceFunction(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<DeviceFunction>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<DeviceFunction> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
