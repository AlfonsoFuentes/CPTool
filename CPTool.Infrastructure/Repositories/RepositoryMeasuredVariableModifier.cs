﻿using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMeasuredVariableModifier : RepositoryBase<MeasuredVariableModifier>, IRepositoryMeasuredVariableModifier
    {
        public RepositoryMeasuredVariableModifier(TableContext dbcontext) : base(dbcontext)
        {
        }
        public override async Task<IReadOnlyList<MeasuredVariableModifier>> GetAllAsync()
        {
            var result = await tableSet.AsNoTrackingWithIdentityResolution()
                .ToListAsync();
            return result;
        }
        //public override async Task<MeasuredVariableModifier> GetByIdAsync(int id)
        //{



        //    var result = await tableSet.AsNoTrackingWithIdentityResolution()
        //       .FirstOrDefaultAsync(x => x.Id == id);
        //    return result!;
        //}
    }
}
