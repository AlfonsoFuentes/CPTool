using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryPipingItem : RepositoryBase<PipingItem>, IRepositoryPipingItem
    {
        public RepositoryPipingItem(TableContext dbcontext) : base(dbcontext)
        {
        }

        public async override Task<PipingItem> GetByIdAsync(int id)
        {
            var result = await dbcontext!.PipingItems!


                .Include(x => x!.pProcessFluid)
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
                 .Include(x => x!.pDiameter)
                 .Include(x => x!.pPipeClass)
                 .Include(x => x!.PipeAccesorys)
                 .Include(x => x!.pMaterial)
                 .Include(x => x!.NozzleStart)
                 .Include(x => x!.NozzleFinish)
                 .Include(x => x!.StartMWOItem)
                 .Include(x => x!.FinishMWOItem)
                 .Include(x => x!.Nozzles!)
                .Include(x => x!.Nozzles!).ThenInclude(x => x.ConnectedTo)


                .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
        }


    }
}
