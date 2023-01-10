

using CPToolCQRS.Infrastructure.Persistence;
using CPTool.PersistenceCQRS.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using CPTool.Domain.Entities;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryBrand : CommandRepository<Brand>, IRepositoryBrand
    {
      
        
        public RepositoryBrand(TableContext dbcontext) : base(dbcontext)
        {
            

            QueryDialog = QueryDialog
               .Include(x => x.BrandSuppliers)
               ;
        }
       

    }
}
