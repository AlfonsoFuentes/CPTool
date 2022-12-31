

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryTaks : CommandRepository<Taks>, IRepositoryTaks
    {
        public RepositoryTaks(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
                .Include(x => x.MWO!)
                   .Include(x => x.MWOItem!)
                   .Include(x => x.PurchaseOrder!)
                   .Include(x => x.DownPayment!);

            QueryDialog = QueryDialog

                    .Include(x => x.MWO!)
                   .Include(x => x.MWOItem!)
                   .Include(x => x.PurchaseOrder!)
                   .Include(x => x.DownPayment!);
        }
        
    }
}
