

using System.Linq.Expressions;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMWOItem : CommandRepository<MWOItem>, IRepositoryMWOItem
    {
        public RepositoryMWOItem(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
              .Include(x => x.Chapter)
                .Include(x => x.UnitaryBasePrize)
                .Include(x => x.MWO)

             .Include(x => x.PurchaseOrderItems!).ThenInclude(y => y!.PurchaseOrder);

            QueryDialog = QueryDialog
                  .Include(x => x.Chapter)
                .Include(x => x.UnitaryBasePrize)
                .Include(x => x.MWO)
                  .Include(x => x.Signals)
             .Include(x => x.PurchaseOrderItems!).ThenInclude(y => y!.PurchaseOrder);
        }



    }
    public class RepositoryMWOItemWithEquipment : CommandRepository<MWOItem>, IRepositoryMWOItemWithEquipment
    {
        public RepositoryMWOItemWithEquipment(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
              .Include(x => x.Chapter)
               
                .Include(x => x.MWO)

             .Include(x => x.EquipmentItem!).ThenInclude(y => y!.eEquipmentType)
             .Include(x => x.EquipmentItem!).ThenInclude(y => y!.eEquipmentTypeSub);

            QueryDialog = QueryDialog
                  .Include(x => x.Chapter)

                .Include(x => x.MWO)

             .Include(x => x.EquipmentItem!).ThenInclude(y => y!.eEquipmentType)
             .Include(x => x.EquipmentItem!).ThenInclude(y => y!.eEquipmentTypeSub);
        }



    }
    public class RepositoryMWOItemWithInstrument : CommandRepository<MWOItem>, IRepositoryMWOItemWithInstrument
    {
        public RepositoryMWOItemWithInstrument(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
              .Include(x => x.Chapter)

                .Include(x => x.MWO)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.Readout)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.MeasuredVariableModifier);

            QueryDialog = QueryDialog
                  .Include(x => x.Chapter)
               
                .Include(x => x.MWO)
                .Include(x=>x.InstrumentItem).ThenInclude(x=>x!.DeviceFunction)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.Readout)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.InstrumentItem).ThenInclude(x => x!.MeasuredVariableModifier)
                  ;
        }



    }
    public class RepositoryMWOItemWithPiping : CommandRepository<MWOItem>, IRepositoryMWOItemWithPiping
    {
        public RepositoryMWOItemWithPiping(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
              .Include(x => x.Chapter)
                
                .Include(x => x.MWO)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pPipeClass)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pDiameter)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pMaterial)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessFluid);

            

            QueryDialog = QueryDialog
                   .Include(x => x.Chapter)

                .Include(x => x.MWO)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pPipeClass)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pDiameter)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pMaterial)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessFluid);
        }



    }
}
