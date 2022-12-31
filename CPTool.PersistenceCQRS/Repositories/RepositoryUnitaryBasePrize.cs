

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryUnitaryBasePrize : CommandRepository<UnitaryBasePrize>, IRepositoryUnitaryBasePrize
    {
        public RepositoryUnitaryBasePrize(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
