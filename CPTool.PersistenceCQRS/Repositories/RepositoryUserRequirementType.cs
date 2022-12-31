

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryUserRequirementType : CommandRepository<UserRequirementType>, IRepositoryUserRequirementType
    {
        public RepositoryUserRequirementType(TableContext dbcontext) : base(dbcontext)
        {
        }
     
    }
}
