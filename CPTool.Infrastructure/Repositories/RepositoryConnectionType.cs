using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryConnectionType : RepositoryBase<ConnectionType>, IRepositoryConnectionType
    {
        public RepositoryConnectionType(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<ConnectionType>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<ConnectionType> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
