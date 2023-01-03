

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryControlLoop : CommandRepository<ControlLoop>, IRepositoryControlLoop
    {
        public RepositoryControlLoop(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
              .Include(x => x.SP)
              .Include(x => x.ControlledVariable).ThenInclude(y=>y!.MWOItem).ThenInclude(x=>x!.Chapter)
              .Include(x => x.ProcessVariableMin)
              .Include(x => x.ProcessVariableMax)
             .Include(x => x.ProcessVariableValue)
              .Include(x => x.MWO)
              .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Chapter);
            QueryDialog = QueryDialog
               .Include(x => x.SP)
              .Include(x => x.ControlledVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Chapter)
              .Include(x => x.ProcessVariableMin)
              .Include(x => x.ProcessVariableMax)
           .Include(x => x.ProcessVariableValue)
              .Include(x => x.MWO)
              .Include(x => x.ProcessVariable).ThenInclude(y => y!.MWOItem).ThenInclude(x => x!.Chapter);
        }
      
    }
}
