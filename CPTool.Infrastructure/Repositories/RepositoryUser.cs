using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .Include(x=>x.UserRequirements)
                .ToListAsync();
            return result;
        }
        //public override async Task<User> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution()
        //          .Include(x => x.UserRequirements)
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
