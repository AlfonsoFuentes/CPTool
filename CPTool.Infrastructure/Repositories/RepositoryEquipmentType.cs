using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryEquipmentType : RepositoryBase<EquipmentType>, IRepositoryEquipmentType
    {
        public RepositoryEquipmentType(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<EquipmentType>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x=>x.EquipmentTypeSubs)
                .ToListAsync();
            return result;
        }
        public override async Task<EquipmentType> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution().Include(x => x.EquipmentTypeSubs)
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
