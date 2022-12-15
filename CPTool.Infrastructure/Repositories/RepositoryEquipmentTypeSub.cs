using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryEquipmentTypeSub : RepositoryBase<EquipmentTypeSub>, IRepositoryEquipmentTypeSub
    {
        public RepositoryEquipmentTypeSub(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<EquipmentTypeSub>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution().Include(x => x.EquipmentType)
                .ToListAsync();
            return result;
        }
        //public override async Task<EquipmentTypeSub> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution().Include(x => x.EquipmentType)
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
