using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryReadout : RepositoryBase<Readout>, IRepositoryReadout
    {
        public RepositoryReadout(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Readout>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<Readout> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
