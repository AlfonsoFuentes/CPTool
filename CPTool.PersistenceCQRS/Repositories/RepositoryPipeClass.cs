

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPipeClass : CommandRepository<PipeClass>, IRepositoryPipeClass
    {
      
        public RepositoryPipeClass(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
           .Include(x => x.PipeDiameters!).ThenInclude(x => x!.InternalDiameter!)
                     .Include(x => x.PipeDiameters!).ThenInclude(x => x!.OuterDiameter!)
                     .Include(x => x.PipeDiameters!).ThenInclude(x => x!.Thickness!);

            QueryDialog = QueryDialog
                  .Include(x => x.PipeDiameters!).ThenInclude(x => x!.InternalDiameter!)
                     .Include(x => x.PipeDiameters!).ThenInclude(x => x!.OuterDiameter!)
                     .Include(x => x.PipeDiameters!).ThenInclude(x => x!.Thickness!);
        }
        
    }
}
