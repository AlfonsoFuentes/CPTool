using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryPipeDiameter : RepositoryBase<PipeDiameter>, IRepositoryPipeDiameter
    {
        public RepositoryPipeDiameter(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<PipeDiameter>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .Include(x => x.dPipeClass)
                .Include(x => x.OuterDiameter)
                .Include(x => x.InternalDiameter)
                .Include(x => x.Thickness)
                .ToListAsync();
            return result;
        }
        //public override async Task<PipeDiameter> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution()
        //        .Include(x => x.dPipeClass)
        //        .Include(x => x.OuterDiameter)
        //        .Include(x => x.InternalDiameter)
        //        .Include(x => x.Thickness)
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
