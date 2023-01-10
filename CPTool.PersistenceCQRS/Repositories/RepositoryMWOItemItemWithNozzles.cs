using System.Linq.Expressions;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMWOItemWithNozzles : CommandRepository<MWOItem>, IRepositoryMWOItemWithNozzles
    {
        public RepositoryMWOItemWithNozzles(TableContext dbcontext) : base(dbcontext)
        {


            QueryList = QueryList
                .Include(x => x.Chapter)
              .Include(x => x.UnitaryBasePrize)
              .Include(x => x.MWO)
              .Include(x => x!.EquipmentType)
              .Include(x => x!.EquipmentTypeSub)
              .Include(x => x.DeviceFunction)
              .Include(x => x.DeviceFunctionModifier)

               .Include(x => x.MeasuredVariable)
               .Include(x => x.MeasuredVariableModifier)
               .Include(x => x.Readout)
               .Include(x => x.PipeClass)
               .Include(x => x.ProcessFluid)
               .Include(x => x.Diameter)
               .Include(x => x.InnerMaterial)
                .Include(x => x.Nozzles!).ThenInclude(y => y.ConnectedTo!)
               

                    ;

            QueryDialog = QueryDialog

                  .Include(x => x.Chapter)
              .Include(x => x.UnitaryBasePrize)
              .Include(x => x.MWO)
              .Include(x => x!.EquipmentType)
              .Include(x => x!.EquipmentTypeSub)
              .Include(x => x.DeviceFunction)
              .Include(x => x.DeviceFunctionModifier)

               .Include(x => x.MeasuredVariable)
               .Include(x => x.MeasuredVariableModifier)
               .Include(x => x.Readout)
               .Include(x => x.PipeClass)
               .Include(x => x.ProcessFluid)
               .Include(x => x.Diameter)
               .Include(x => x.InnerMaterial)
                .Include(x => x.Nozzles!).ThenInclude(y => y.ConnectedTo!)


                    ;
        }

       
    }
}

