

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryUserRequirement : CommandRepository<UserRequirement>, IRepositoryUserRequirement
    {
        public RepositoryUserRequirement(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
                .Include(x => x.MWO!)
                   .Include(x => x.UserRequirementType!)
                   .Include(x => x.RequestedBy!);

            QueryDialog = QueryDialog
                .Include(x => x.MWO!)
                   .Include(x => x.UserRequirementType!)
                   .Include(x => x.RequestedBy!);
        }
       
    }
}
