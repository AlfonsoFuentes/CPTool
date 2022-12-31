

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryFieldLocation : CommandRepository<FieldLocation>, IRepositoryFieldLocation
    {
        public RepositoryFieldLocation(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
