

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryDownPayment : CommandRepository<DownPayment>, IRepositoryDownPayment
    {
        public RepositoryDownPayment(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
              .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.MWO);
            QueryDialog = QueryDialog
                .Include(x => x!.PurchaseOrder).ThenInclude(x => x!.MWO);
        }
       
    }
}
