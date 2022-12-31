using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryNozzle : RepositoryBase<Nozzle>, IRepositoryNozzle
    {
        public RepositoryNozzle(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Nozzle>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x=>x.nGasket)
                .Include(x => x.nPipeClass)
                 .Include(x => x.PipeDiameter)
                  .Include(x => x.ConnectedTo)
                  .Include(x => x.ConnectionType)
                   .Include(x => x.EquipmentItem)
                   .Include(x => x.InstrumentItem)
                   .Include(x => x.PipingItem)
                   .Include(x => x.PipeAccesory)
                .ToListAsync();
            return result;
        }
        public override async Task<Nozzle> GetByIdAsync(int id)
        {



            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .Include(x => x.nGasket)
                .Include(x => x.nPipeClass)
                 .Include(x => x.PipeDiameter)
                  .Include(x => x.ConnectedTo)
                  .Include(x => x.ConnectionType)
                   .Include(x => x.EquipmentItem)
                   .Include(x => x.InstrumentItem)
                   .Include(x => x.PipingItem)
                   .Include(x => x.PipeAccesory)
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
