using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryGasket : RepositoryBase<Gasket>, IRepositoryGasket
    {
        public RepositoryGasket(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Gasket>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        //public override async Task<Gasket> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
