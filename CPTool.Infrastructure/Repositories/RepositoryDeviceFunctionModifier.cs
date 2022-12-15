using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryDeviceFunctionModifier : RepositoryBase<DeviceFunctionModifier>, IRepositoryDeviceFunctionModifier
    {
        public RepositoryDeviceFunctionModifier(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<DeviceFunctionModifier>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        //public override async Task<DeviceFunctionModifier> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
