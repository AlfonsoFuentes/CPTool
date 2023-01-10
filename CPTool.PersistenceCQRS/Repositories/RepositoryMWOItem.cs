

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
              .Include(x => x!.EquipmentType)
              .Include(x => x!.EquipmentTypeSub)
              .Include(x => x.DeviceFunction)
              .Include(x => x.DeviceFunctionModifier)
               .Include(x => x!.Brand)
               .Include(x => x!.Supplier)
               .Include(x => x.MeasuredVariable)
               .Include(x => x.MeasuredVariableModifier)
               .Include(x => x.Readout)
               .Include(x => x.PipeClass)
               .Include(x => x.ProcessFluid)
               .Include(x => x.Diameter)
               .Include(x => x.InnerMaterial)
               .Include(x => x.PurchaseOrderItems!).ThenInclude(x=>x.PurchaseOrder);
            ;


            QueryDialog = QueryDialog
                         .Include(x => x.Chapter)
                        .Include(x => x.UnitaryBasePrize)
                        .Include(x => x.MWO)
                          .Include(x => x.Signals)

                      .Include(x => x!.Brand)
                      .Include(x => x!.Supplier)
                      .Include(x => x!.InnerMaterial)
                      .Include(x => x!.MaterialOuter)

                      .Include(x => x!.ProcessCondition)
                      .Include(x => x!.ProcessFluid)

                      .Include(x => x!.EquipmentType)
                      .Include(x => x!.EquipmentTypeSub)

                      .Include(x => x!.PipeClass!)

                      .Include(x => x!.Diameter!)

                      .Include(x => x!.NozzleFinish!)
                      .Include(x => x!.NozzleStart!)

                      .Include(x => x.DeviceFunction)
                      .Include(x => x.DeviceFunctionModifier)

                      .Include(x => x.MeasuredVariable)
                      .Include(x => x.MeasuredVariableModifier)
                      .Include(x => x.Readout)
                      .Include(x => x.Nozzles!).ThenInclude(x=>x!.ConnectedTo!)
                      .Include(x => x.PipeAccesorys)

                     .Include(x => x.PurchaseOrderItems!).ThenInclude(x => x.PurchaseOrder);
        }



    }

}
