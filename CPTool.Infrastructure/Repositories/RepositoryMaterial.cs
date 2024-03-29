﻿using CPTool.Application.Contracts;
using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMaterial : RepositoryBase<Material>, IRepositoryMaterial
    {
        public RepositoryMaterial(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<Material>> GetAllAsync()
        {
             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        public override async Task<Material> GetByIdAsync(int id)
        {



             var result = await tableSet.AsQueryable().AsNoTrackingWithIdentityResolution()
               .FirstOrDefaultAsync(x => x.Id == id);
            return result!;
        }
    }
}
