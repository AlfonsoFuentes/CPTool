using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryElectricalBox : RepositoryBase<ElectricalBox>, IRepositoryElectricalBox
    {
        public RepositoryElectricalBox(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<ElectricalBox>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<ElectricalBox> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
