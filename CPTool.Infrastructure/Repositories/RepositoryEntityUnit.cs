using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryEntityUnit : RepositoryBase<EntityUnit>, IRepositoryEntityUnit
    {
        public RepositoryEntityUnit(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<EntityUnit>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<EntityUnit> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
