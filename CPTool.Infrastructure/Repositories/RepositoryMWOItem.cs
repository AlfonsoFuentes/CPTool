using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMWOItem : RepositoryBase<MWOItem>, IRepositoryMWOItem
    {
        public RepositoryMWOItem(TableContext dbcontext) : base(dbcontext)
        {
        }


        public async Task<MWOItem> GetMWOItemIdAsync(int id)
        {
            var result = await dbcontext!.MWOItems!
                 .Include(x => x.Chapter)
                 .Include(x => x.MWO)
                 .Include(x => x.UnitaryBasePrize)
                 .Include(x => x.EquipmentItem).ThenInclude(y => y!.Nozzles)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessFluid)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.SpecificCp)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.ThermalConductivity)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.SpecificEnthalpy)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.EnthalpyFlow)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.Viscosity)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.Density)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.VolumetricFlow)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.MassFlow)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.Temperature)
                 .Include(x => x.EquipmentItem).ThenInclude(x => x!.eProcessCondition).ThenInclude(x => x!.Pressure)

                 .Include(x => x.InstrumentItem).ThenInclude(y => y!.Nozzles)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessFluid)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.SpecificCp)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.ThermalConductivity)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.SpecificEnthalpy)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.EnthalpyFlow)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.Viscosity)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.Density)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.VolumetricFlow)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.MassFlow)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.Temperature)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.iProcessCondition).ThenInclude(x => x!.Pressure)
                 .Include(x => x.InstrumentItem).ThenInclude(x=>x!.DeviceFunction)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.DeviceFunctionModifier)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.Readout)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.MeasuredVariable)
                 .Include(x => x.InstrumentItem).ThenInclude(x => x!.MeasuredVariableModifier)

                 .Include(x => x.PipingItem).ThenInclude(y => y!.Nozzles)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessFluid)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.SpecificCp)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.ThermalConductivity)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.SpecificEnthalpy)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.EnthalpyFlow)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.Viscosity)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.Density)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.VolumetricFlow)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.MassFlow)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.Temperature)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pProcessCondition).ThenInclude(x => x!.Pressure)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pDiameter)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pPipeClass)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.PipeAccesorys)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.pMaterial)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.NozzleStart)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.NozzleFinish)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.StartMWOItem)
                 .Include(x => x.PipingItem).ThenInclude(x => x!.FinishMWOItem)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
        }
    }
}
