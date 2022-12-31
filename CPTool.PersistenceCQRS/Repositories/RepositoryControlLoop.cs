

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryControlLoop : CommandRepository<ControlLoop>, IRepositoryControlLoop
    {
        public RepositoryControlLoop(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
              .Include(x => x.SP)
              .Include(x => x.ControlledVariable)
              .Include(x => x.ProcessVariableMin)
              .Include(x => x.ProcessVariableMax)
              .Include(x => x.ControlledVariableMax)
              .Include(x => x.ControlledVariableMin)
              .Include(x => x.MWO)
              .Include(x => x.ProcessVariable);
            QueryDialog = QueryDialog
               .Include(x => x.SP)
              .Include(x => x.ControlledVariable)
              .Include(x => x.ProcessVariableMin)
              .Include(x => x.ProcessVariableMax)
              .Include(x => x.ControlledVariableMax)
              .Include(x => x.ControlledVariableMin)
              .Include(x => x.MWO)
              .Include(x => x.ProcessVariable);
        }
      
    }
}
