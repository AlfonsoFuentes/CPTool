
global using CPTool.Application.Contracts;
global using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryWire : RepositoryBase<Wire>, IRepositoryWire
    {
        public RepositoryWire(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Wire>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<Wire> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
