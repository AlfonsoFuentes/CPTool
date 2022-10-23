using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryEquipmentItem : RepositoryBase<EquipmentItem>, IRepositoryEquipmentItem
    {
        public RepositoryEquipmentItem(TableContext dbcontext) : base(dbcontext)
        {
        }

        public async override Task<EquipmentItem> GetByIdAsync(int id)
        {
            var result = await dbcontext!.EquipmentItems!


                .Include(x => x!.eProcessFluid)
                .Include(x => x!.eProcessCondition)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.SpecificCp)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.ThermalConductivity)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.SpecificEnthalpy)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.EnthalpyFlow)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.Viscosity)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.Density)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.VolumetricFlow)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.MassFlow)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.Temperature)
                .Include(x => x!.eProcessCondition).ThenInclude(x => x!.Pressure)
                .Include(x => x!.Nozzles!)
                .Include(x => x!.Nozzles!).ThenInclude(x => x.ConnectedTo)


                .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
        }


    }
}
