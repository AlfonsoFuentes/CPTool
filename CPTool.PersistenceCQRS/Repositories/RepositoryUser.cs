

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryUser : CommandRepository<User>, IRepositoryUser
    {
        public RepositoryUser(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
