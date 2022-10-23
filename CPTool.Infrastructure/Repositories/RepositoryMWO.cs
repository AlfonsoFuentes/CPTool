using CPTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMWO : RepositoryBase<MWO>, IRepositoryMWO
    {
        public RepositoryMWO(TableContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<MWO> GetMWO_ItemsIdAsync(int id)
        {
            var result = await dbcontext!.MWOs!
                 .Include(x => x.MWOType)
                 .Include(x => x.MWOItems).ThenInclude(x => x.Chapter).ThenInclude(x => x!.MWOItems)
                 .Include(x => x.MWOItems).ThenInclude(x => x.EquipmentItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.EquipmentItem).ThenInclude(y => y!.eEquipmentType)
                 .Include(x => x.MWOItems).ThenInclude(x => x.EquipmentItem).ThenInclude(y => y!.eEquipmentTypeSub)
        
                 .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem).ThenInclude(y => y!.DeviceFunction)
                 .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem).ThenInclude(y => y!.DeviceFunctionModifier)
                 .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem).ThenInclude(y => y!.Readout)
                 .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem).ThenInclude(y => y!.MeasuredVariable)
                 .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem).ThenInclude(y => y!.MeasuredVariable)
             
                 .Include(x => x.MWOItems).ThenInclude(x => x.PipingItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.PipingItem).ThenInclude(y => y!.pDiameter)
                 .Include(x => x.MWOItems).ThenInclude(x => x.PipingItem).ThenInclude(y => y!.pProcessFluid)
                 .Include(x => x.MWOItems).ThenInclude(x => x.PipingItem).ThenInclude(y => y!.pMaterial)
          
                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;

        }
        public async Task<MWO> GetMWO_PurchaseOrderIdAsync(int id)
        {
            var result = await dbcontext!.MWOs!
                 .Include(x => x.MWOType)
                .Include(x => x.MWOItems).ThenInclude(x => x.PurchaseOrders)

                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;

        }
        
    }
}
