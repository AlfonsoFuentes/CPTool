using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryChapter : RepositoryBase<Chapter>, IRepositoryChapter
    {
        public RepositoryChapter(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Chapter>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        //public override async Task<Chapter> GetByIdAsync(int id)
        //{

           

        //    var result = await tableSet.AsNoTrackingWithIdentityResolution().AsNoTrackingWithIdentityResolution()
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
