using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryPurchaseOrder : RepositoryBase<PurchaseOrder>, IRepositoryPurchaseOrder
    {
        public RepositoryPurchaseOrder(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<PurchaseOrder>> GetAllAsync()
        {
            var result = await dbcontext.PurchaseOrders!.ToListAsync();

                //.Include(x => x!.MWO)
                //.Include(x => x!.DownPayments)
                //.Include(x => x!.PurchaseOrderItems)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.AlterationItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.FoundationItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.StructuralItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.EquipmentItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.PipingItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.InstrumentItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.EHSItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.PaintingItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.EngineeringCostItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.TaxesItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.ContingencyItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.ElectricalItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.InsulationItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.AlterationItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.AlterationItem)
                //.Include(x => x!.PurchaseOrderItems).ThenInclude(yx => yx!.MWOItem).ThenInclude(yx => yx!.AlterationItem)
                //.Include(x => x!.pBrand)
                //.Include(x => x!.pSupplier)

                //.ToListAsync();
            return result;
        }
        //public override async Task<PurchaseOrder> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
        //              .Include(x => x.MWO)
        //        .Include(x => x.DownPayments)
        //        .Include(x => x.PurchaseOrderItems)
        //        .Include(x => x.pBrand)
        //        .Include(x => x.pSupplier)
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
