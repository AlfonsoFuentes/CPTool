using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMWOType : RepositoryBase<MWOType>, IRepositoryMWOType
    {
        public RepositoryMWOType(TableContext dbcontext) : base(dbcontext)
        {
        }

        public override async Task<MWOType> GetByIdAsync(int id)
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()

                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
           

        }

        public override async Task<IReadOnlyList<MWOType>> GetAllAsync()
        {
            var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()

                .ToListAsync();

            return result!;
        }
    }
}
