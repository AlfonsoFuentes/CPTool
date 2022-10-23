using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryInstrumentItem : RepositoryBase<InstrumentItem>, IRepositoryInstrumentItem
    {
        public RepositoryInstrumentItem(TableContext dbcontext) : base(dbcontext)
        {
        }

        public async override Task<InstrumentItem> GetByIdAsync(int id)
        {
            var result = await dbcontext!.InstrumentItems!


                .Include(x => x!.iProcessCondition)
                 .Include(x => x!.iProcessFluid)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.SpecificCp)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.ThermalConductivity)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.SpecificEnthalpy)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.EnthalpyFlow)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.Viscosity)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.Density)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.VolumetricFlow)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.MassFlow)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.Temperature)
                 .Include(x => x!.iProcessCondition).ThenInclude(x => x!.Pressure)
                 .Include(x => x!.DeviceFunction)
                 .Include(x => x!.DeviceFunctionModifier)
                 .Include(x => x!.Readout)
                 .Include(x => x!.MeasuredVariable)
                 .Include(x => x!.MeasuredVariableModifier)
                 .Include(x => x!.Nozzles!)
                .Include(x => x!.Nozzles!).ThenInclude(x => x.ConnectedTo)


                .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
        }


    }
}
