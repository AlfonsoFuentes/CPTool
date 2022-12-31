

using System.Linq.Expressions;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryNozzle : CommandRepository<Nozzle>, IRepositoryNozzle
    {
        public RepositoryNozzle(TableContext dbcontext) : base(dbcontext)
        {
          
              
            QueryList = QueryList
              .Include(x => x.nPipeClass!)
                .Include(x => x.PipeDiameter!)
                .Include(x => x.ConnectionType!)
                .Include(x => x.nGasket!)
                .Include(x => x.nMaterial!)
                .Include(x => x.EquipmentItem!)
                .Include(x => x.InstrumentItem!)
                .Include(x => x.PipingItem!)
                .Include(x => x.ConnectedTo!);

            QueryDialog = QueryDialog
                  .Include(x => x.nPipeClass!)
                .Include(x => x.PipeDiameter!)
                .Include(x => x.ConnectionType!)
                .Include(x => x.nGasket!)
                .Include(x => x.nMaterial!)
                 .Include(x => x.EquipmentItem!)
                .Include(x => x.InstrumentItem!)
                .Include(x => x.PipingItem!)
                .Include(x => x.ConnectedTo!);
        }
        
    }
}
