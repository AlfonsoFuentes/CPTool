

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPipeDiameter : CommandRepository<PipeDiameter>, IRepositoryPipeDiameter
    {
        public RepositoryPipeDiameter(TableContext dbcontext) : base(dbcontext)
        {
          
            QueryList = QueryList
          .Include(x => x.InternalDiameter!)
                   .Include(x => x.OuterDiameter!)
                   .Include(x => x.Thickness!);

            QueryDialog = QueryDialog
                  .Include(x => x.InternalDiameter!)
                   .Include(x => x.OuterDiameter!)
                   .Include(x => x.Thickness!);
        }
       
    }
}
