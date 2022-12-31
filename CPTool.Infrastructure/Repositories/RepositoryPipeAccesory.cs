using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryPipeAccesory : RepositoryBase<PipeAccesory>, IRepositoryPipeAccesory
    {
        public RepositoryPipeAccesory(TableContext dbcontext) : base(dbcontext)
        {
        }

        public async override Task<PipeAccesory> GetByIdAsync(int id)
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()


                .Include(x => x!.pPipingItem)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.SpecificCp)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.ThermalConductivity)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.SpecificEnthalpy)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.EnthalpyFlow)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Viscosity)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Density)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.VolumetricFlow)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.MassFlow)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Temperature)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Pressure)
                 .Include(x => x!.paProcessFluid)
                 .Include(x => x!.Friction)
                 .Include(x => x!.Reynold)
                 .Include(x => x!.LevelInlet)
                 .Include(x => x!.LevelOutlet)
                 .Include(x => x!.FrictionDropPressure)
                 .Include(x => x!.OverallDropPressure)
                 .Include(x => x!.ElevationChange)
                 .Include(x => x!.Nozzles!)
                 .Include(x => x!.Nozzles!).ThenInclude(x => x.PipeDiameter)
                 .Include(x => x!.Nozzles!).ThenInclude(x => x.nPipeClass)
                 .Include(x => x!.Nozzles!).ThenInclude(x => x.nMaterial)

                 .Include(x => x!.Nozzles!).ThenInclude(x => x.ConnectedTo)


                .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
        }
        public async override Task<IReadOnlyList<PipeAccesory>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()


                .Include(x => x!.pPipingItem)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.SpecificCp)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.ThermalConductivity)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.SpecificEnthalpy)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.EnthalpyFlow)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Viscosity)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Density)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.VolumetricFlow)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.MassFlow)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Temperature)
                 .Include(x => x!.pProcessCondition).ThenInclude(x => x!.Pressure)
                 .Include(x => x!.paProcessFluid)
                 .Include(x => x!.Friction)
                 .Include(x => x!.Reynold)
                 .Include(x => x!.LevelInlet)
                 .Include(x => x!.LevelOutlet)
                 .Include(x => x!.FrictionDropPressure)
                 .Include(x => x!.OverallDropPressure)
                 .Include(x => x!.ElevationChange)
                 .Include(x => x!.Nozzles!)
                 .Include(x => x!.Nozzles!).ThenInclude(x => x.PipeDiameter)
                 .Include(x => x!.Nozzles!).ThenInclude(x => x.nPipeClass)
                 .Include(x => x!.Nozzles!).ThenInclude(x => x.nMaterial)

                 .Include(x => x!.Nozzles!).ThenInclude(x => x.ConnectedTo).ToListAsync();

            return result!;
        }

    }
}
