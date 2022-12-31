using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryDownPayment : RepositoryBase<DownPayment>, IRepositoryDownPayment
    {
        public RepositoryDownPayment(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<DownPayment>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x=>x.Taks)
                .Include(x => x.PurchaseOrder).ThenInclude(x=>x!.MWO)
         
                .ToListAsync();
            return result;
        }
        public override async Task<DownPayment> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution().Include(x => x.Taks)
                .Include(x => x.PurchaseOrder)
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
