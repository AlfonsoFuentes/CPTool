using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryTaks : RepositoryBase<Taks>, IRepositoryTaks
    {
        public RepositoryTaks(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Taks>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x=>x.DownPayment)
                .Include(x => x.PurchaseOrder)
                .Include(x => x.MWOItem)
                .Include(x => x.MWO)
                .ToListAsync();
            return result;
        }
        public override async Task<Taks> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                 .Include(x => x.DownPayment)
               .Include(x => x.PurchaseOrder)
               .Include(x => x.MWOItem)
               .Include(x => x.MWO)
              .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
