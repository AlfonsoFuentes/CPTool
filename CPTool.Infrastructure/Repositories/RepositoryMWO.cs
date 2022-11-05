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
                 .Include(x => x.MWOItems).ThenInclude(x => x.MWOItemCurrencyValues)
                 .Include(x => x.MWOItems).ThenInclude(x => x.UnitaryBasePrize)
                 .Include(x => x.MWOItems).ThenInclude(x => x.AlterationItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.FoundationItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.StructuralItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.ElectricalItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.PaintingItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.EHSItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.TaxesItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.TestingItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.ContingencyItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.EngineeringCostItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.EquipmentItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem)
                 .Include(x => x.MWOItems).ThenInclude(x => x.PipingItem)

                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;

        }
        public async Task<MWO> GetMWO_PurchaseOrderIdAsync(int id)
        {
            var result = await dbcontext!.MWOs!
                 .Include(x => x.MWOType)
                 //.Include(x => x.MWOItems).ThenInclude(x => x.PurchaseOrderMWOItems)

                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;

        }
        public override async Task<IReadOnlyList<MWO>> GetAllAsync()
        {
            var result = await dbcontext!.MWOs!
                .Include(x => x.MWOItems).ThenInclude(x => x.MWOItemCurrencyValues)
                .Include(x => x.MWOItems).ThenInclude(x => x.UnitaryBasePrize)
                .Include(x => x.MWOItems).ThenInclude(x => x.AlterationItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.FoundationItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.StructuralItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.ElectricalItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.PaintingItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.EHSItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.TaxesItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.TestingItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.ContingencyItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.EngineeringCostItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.EquipmentItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.InstrumentItem)
                .Include(x => x.MWOItems).ThenInclude(x => x.PipingItem)

                .ToListAsync();

            return result!;
        }
    }
}
