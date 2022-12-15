using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositorySignalType : RepositoryBase<SignalType>, IRepositorySignalType
    {
        public RepositorySignalType(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<SignalType>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        //public override async Task<SignalType> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution()
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
