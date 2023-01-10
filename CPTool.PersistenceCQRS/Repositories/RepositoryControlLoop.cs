

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryControlLoop : CommandRepository<ControlLoop>, IRepositoryControlLoop
    {
        public RepositoryControlLoop(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
              .Include(x => x.SP)
              .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Chapter)
            .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentType)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentTypeSub)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Readout)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariableModifier)
              .Include(x => x.ProcessVariableMin)
              .Include(x => x.ProcessVariableMax)
             .Include(x => x.ProcessVariableValue)
              .Include(x => x.MWO)
              .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Chapter)
            .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentType)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentTypeSub)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Readout)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariableModifier);
            QueryDialog = QueryDialog
              .Include(x => x.SP)
              .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Chapter)
            .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentType)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentTypeSub)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Readout)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariableModifier)
              .Include(x => x.ProcessVariableMin)
              .Include(x => x.ProcessVariableMax)
             .Include(x => x.ProcessVariableValue)
              .Include(x => x.MWO)
              .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Chapter)
            .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentType)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.EquipmentTypeSub)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunction)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.DeviceFunctionModifier)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Readout)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariable)
                .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.MeasuredVariableModifier);
        }

    }
}
