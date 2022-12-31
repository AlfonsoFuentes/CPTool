using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositorySignalModifier : RepositoryBase<SignalModifier>, IRepositorySignalModifier
    {
        public RepositorySignalModifier(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<SignalModifier>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               
                .ToListAsync();
            return result;
        }
        public override async Task<SignalModifier> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
