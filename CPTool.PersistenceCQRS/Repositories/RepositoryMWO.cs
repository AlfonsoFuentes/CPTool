
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMWO : CommandRepository<MWO>, IRepositoryMWO
    {
        public RepositoryMWO(TableContext dbcontext) : base(dbcontext)
        {

            QueryList = QueryList
           .Include(x => x.MWOItems)
              .Include(x => x.PurchaseOrders).ThenInclude(y => y.pBrand)
              .Include(x => x!.PurchaseOrders!).ThenInclude(y => y!.PurchaseOrderItems!).ThenInclude(z => z!.MWOItem!);
            QueryDialog = QueryDialog
                 .Include(x => x.MWOType)
                 .Include(x => x.MWOItems)
              .Include(x => x.PurchaseOrders).ThenInclude(y => y.pBrand)
              .Include(x => x!.PurchaseOrders!).ThenInclude(y => y!.PurchaseOrderItems!).ThenInclude(z => z!.MWOItem!);
        }



    }
}
