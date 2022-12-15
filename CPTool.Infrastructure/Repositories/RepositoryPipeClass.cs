using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryPipeClass : RepositoryBase<PipeClass>, IRepositoryPipeClass
    {
        public RepositoryPipeClass(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<PipeClass>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution().Include(x=>x.PipeDiameters)
                .ToListAsync();
            return result;
        }
        //public override async Task<PipeClass> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().Include(x => x.PipeDiameters)
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
