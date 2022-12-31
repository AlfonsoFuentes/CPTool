using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryProcessFluid : RepositoryBase<ProcessFluid>, IRepositoryProcessFluid
    {
        public RepositoryProcessFluid(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<ProcessFluid>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x=>x.PropertyPackage)
                .ToListAsync();
            return result;
        }
        public override async Task<ProcessFluid> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x => x.PropertyPackage)
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
