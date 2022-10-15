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
                 .Include(x => x.MWOItems).ThenInclude(x=>x.EquipmentItem)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;

        }
        public async Task<MWO> GetMWO_PurchaseOrderIdAsync(int id)
        {
            var result = await dbcontext!.MWOs!
                 .Include(x => x.MWOType)
                .Include(x=>x.MWOItems).ThenInclude(x=>x.PurchaseOrders)

                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;

        }
    }
}
