

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryProcessFluid : CommandRepository<ProcessFluid>, IRepositoryProcessFluid
    {


        public RepositoryProcessFluid(TableContext dbcontext) : base(dbcontext)
        {
            QueryList = QueryList
                .Include(x=>x.PropertyPackage)
                ;
            QueryDialog = QueryDialog
               .Include(x => x.PropertyPackage)
               ;
        }

      
    }
}
