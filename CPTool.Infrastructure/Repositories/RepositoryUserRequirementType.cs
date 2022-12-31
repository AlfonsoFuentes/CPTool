using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryUserRequirementType : RepositoryBase<UserRequirementType>, IRepositoryUserRequirementType
    {
        public RepositoryUserRequirementType(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<UserRequirementType>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<UserRequirementType> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
