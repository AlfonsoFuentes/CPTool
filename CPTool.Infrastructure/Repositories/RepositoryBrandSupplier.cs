using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryBrandSupplier : RepositoryBase<BrandSupplier>, IRepositoryBrandSupplier
    {
        public RepositoryBrandSupplier(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
