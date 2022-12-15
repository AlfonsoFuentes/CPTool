using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryProcessCondition : RepositoryBase<ProcessCondition>, IRepositoryProcessCondition
    {
        public RepositoryProcessCondition(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<ProcessCondition>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .Include(x=>x.Pressure)
                .Include(x => x.Temperature)
                .Include(x => x.MassFlow)
                .Include(x => x.VolumetricFlow)
                .Include(x => x.Density)
                .Include(x => x.Viscosity)
                .Include(x => x.EnthalpyFlow)
                .Include(x => x.SpecificEnthalpy)
                .Include(x => x.ThermalConductivity)
                .Include(x => x.SpecificCp)
                .ToListAsync();
            return result;
        }
        //public override async Task<ProcessCondition> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution()
        //         .Include(x => x.Pressure)
        //        .Include(x => x.Temperature)
        //        .Include(x => x.MassFlow)
        //        .Include(x => x.VolumetricFlow)
        //        .Include(x => x.Density)
        //        .Include(x => x.Viscosity)
        //        .Include(x => x.EnthalpyFlow)
        //        .Include(x => x.SpecificEnthalpy)
        //        .Include(x => x.ThermalConductivity)
        //        .Include(x => x.SpecificCp)
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
