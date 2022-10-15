using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMWOItem : RepositoryBase<MWOItem>, IRepositoryMWOItem
    {
        public RepositoryMWOItem(TableContext dbcontext) : base(dbcontext)
        {
        }


        public async Task<MWOItem> GetMWOItemIdAsync(int id)
        {
            var result = await dbcontext!.MWOItems!
                 .Include(x => x.Chapter)
                 .Include(x => x.MWO)
                 .Include(x => x.UnitaryBasePrize)
                 .Include(x => x.EquipmentItem).ThenInclude(y => y!.Nozzles)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.ProcessCondition)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.ProcessFluidEquipment)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
        }
    }
}
