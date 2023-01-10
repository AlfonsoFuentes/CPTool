

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositorySignal : CommandRepository<Signal>, IRepositorySignal
    {
        public RepositorySignal(TableContext dbcontext) : base(dbcontext)
        {
            QueryList = QueryList
                    .Include(x => x.MWO!)
                    .Include(x => x.Wire!)
                    .Include(x => x.FieldLocation!)
                    .Include(x => x.ElectricalBox!)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.Chapter)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.EquipmentType)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.EquipmentTypeSub)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.DeviceFunction)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.DeviceFunctionModifier)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.Readout)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.MeasuredVariable)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.MeasuredVariableModifier)
                    .Include(x => x.SignalType!)
                   .Include(x => x.SignalModifier!);

            QueryDialog = QueryDialog

                    .Include(x => x.MWO!)
                    .Include(x => x.Wire!)
                    .Include(x => x.FieldLocation!)
                    .Include(x => x.ElectricalBox!)
                    .Include(x => x.MWOItem!).ThenInclude(x=>x.Chapter)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.EquipmentType)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.EquipmentTypeSub)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.DeviceFunction)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.DeviceFunctionModifier)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.Readout)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.MeasuredVariable)
                    .Include(x => x.MWOItem!).ThenInclude(x => x.MeasuredVariableModifier)
                    .Include(x => x.SignalType!)
                   .Include(x => x.SignalModifier!);
        }
       
     
    }
}
