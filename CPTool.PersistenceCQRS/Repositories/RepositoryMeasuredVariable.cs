

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMeasuredVariable : CommandRepository<MeasuredVariable>, IRepositoryMeasuredVariable
    {
        public RepositoryMeasuredVariable(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
