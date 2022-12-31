using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryPropertyPackage : RepositoryBase<PropertyPackage>, IRepositoryPropertyPackage
    {
        public RepositoryPropertyPackage(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<PropertyPackage>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x => x.ProcessFluids)
                .ToListAsync();
            return result;
        }
        public override async Task<PropertyPackage> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution().Include(x => x.ProcessFluids)
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
