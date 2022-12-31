using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryFieldLocation : RepositoryBase<FieldLocation>, IRepositoryFieldLocation
    {
        public RepositoryFieldLocation(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<FieldLocation>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<FieldLocation> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
