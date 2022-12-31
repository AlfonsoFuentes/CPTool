namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPipingItem : CommandRepository<PipingItem>, IRepositoryPipingItem
    {
        public RepositoryPipingItem(TableContext dbcontext) : base(dbcontext)
        {


            QueryList = QueryList
                 
                    .Include(x => x.pProcessFluid!)
                    .Include(x => x.pPipeClass!)
                   .Include(x => x.pMaterial!)
                   .Include(x => x.pDiameter!);

            QueryDialog = QueryDialog

                  .Include(x => x.pPipeClass!)
                  .Include(x => x.pPipeClass!)
                  .Include(x => x.pProcessFluid!)
                   .Include(x => x.pMaterial!)
                   .Include(x => x.pDiameter!)
                   .Include(x => x.pProcessCondition!)
                   .Include(x => x.Nozzles!)
                   .Include(x => x.NozzleFinish!)
                   .Include(x => x.NozzleStart!)
                   .Include(x => x.StartMWOItem!)
                   .Include(x=>x.FinishMWOItem)
                   ;
        }

    }
}

