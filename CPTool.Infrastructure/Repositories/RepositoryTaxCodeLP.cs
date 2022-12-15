using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryTaxCodeLP : RepositoryBase<TaxCodeLP>, IRepositoryTaxCodeLP
    {
        public RepositoryTaxCodeLP(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<TaxCodeLP>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        //public override async Task<TaxCodeLP> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution()
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
