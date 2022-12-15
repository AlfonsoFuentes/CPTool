using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryTaxCodeLD : RepositoryBase<TaxCodeLD>, IRepositoryTaxCodeLD
    {
        public RepositoryTaxCodeLD(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<TaxCodeLD>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        //public override async Task<TaxCodeLD> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution()
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
