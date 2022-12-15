using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMWOType : RepositoryBase<MWOType>, IRepositoryMWOType
    {
        public RepositoryMWOType(TableContext dbcontext) : base(dbcontext)
        {
        }

        //public override async Task<MWOType> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        var result = await tableSet.AsNoTrackingWithIdentityResolution()

        //         .FirstOrDefaultAsync(x => x.Id == id);

        //        return result!;

        //    }
        //    catch (Exception ex)
        //    {
        //        string exm = ex.Message;
        //    }

        //    return null!;

        //}

        public override async Task<IReadOnlyList<MWOType>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()

                .ToListAsync();

            return result!;
        }
    }
}
