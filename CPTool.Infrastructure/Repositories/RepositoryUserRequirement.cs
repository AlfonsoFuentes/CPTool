using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryUserRequirement : RepositoryBase<UserRequirement>, IRepositoryUserRequirement
    {
        public RepositoryUserRequirement(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<UserRequirement>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                  .Include(x => x.UserRequirementType)
                .Include(x => x.MWO)
                .Include(x => x.RequestedBy)
                .ToListAsync();
            return result;
        }
        public override async Task<UserRequirement> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .Include(x => x.UserRequirementType)
               .Include(x => x.MWO)
               .Include(x => x.RequestedBy)

              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
