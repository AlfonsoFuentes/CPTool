using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryControlLoop : RepositoryBase<ControlLoop>, IRepositoryControlLoop
    {
        public RepositoryControlLoop(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<ControlLoop>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
             
                .Include(x => x.ControlledVariable).ThenInclude(x=>x.SignalModifier)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.EquipmentItem)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.EquipmentItem).ThenInclude(x=>x!.eEquipmentType)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.EquipmentItem).ThenInclude(x => x!.eEquipmentTypeSub)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.Readout)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.ControlledVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariableModifier)
                .Include(x => x.ProcessVariable).ThenInclude(x => x.SignalModifier)
                .Include(x => x.ProcessVariable).ThenInclude(x=>x!.MWOItem)
            
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.EquipmentItem).ThenInclude(x => x!.eEquipmentType)
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.EquipmentItem).ThenInclude(x => x!.eEquipmentTypeSub)
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem)
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.Readout)
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.ProcessVariable).ThenInclude(x => x!.MWOItem).ThenInclude(x => x!.InstrumentItem).ThenInclude(x => x!.MeasuredVariableModifier)
                .Include(x => x.ProcessVariableMax)
                .Include(x => x.ProcessVariableMin)
                .Include(x => x.SP)
                .Include(x => x.ProcessVariableValue)
                .ToListAsync();
            return result;
        }
        //public override async Task<ControlLoop> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
        //        .Include(x => x.ControlledVariable)
        //        .Include(x => x.ProcessVariable)
        //        .Include(x => x.ProcessVariableMax)
        //         .Include(x => x.ProcessVariableMin)
        //         .Include(x => x.SP)
        //          .Include(x => x.ProcessVariableValue)
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
