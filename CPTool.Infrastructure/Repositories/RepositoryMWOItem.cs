﻿using CPTool.Domain.Entities;

namespace CPTool.Infrastructure.Repositories
{
    public class RepositoryMWOItem : RepositoryBase<MWOItem>, IRepositoryMWOItem
    {
        public RepositoryMWOItem(TableContext dbcontext) : base(dbcontext)
        {
        }
       
        public async Task<MWO> GetMWOIdAsync(int id)
        {
            var result = await dbcontext!.MWOs!
                 .Include(x => x.MWOType)
                 .Include(x => x.MWOItems).ThenInclude(hh => hh.Chapter)
                 .Include(x => x.MWOItems).ThenInclude(hh => hh.EquipmentItem)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;

        }

        public async Task<MWOItem> GetMWOItemIdAsync(int id)
        {
            var result = await dbcontext!.MWOItems!
                 .Include(x => x.Chapter)
                 .Include(x => x.MWO)
                 .Include(x => x.UnitaryBasePrize)
                 .Include(x=>x.EquipmentItem)
                 .FirstOrDefaultAsync(x => x.Id == id);

            return result!;
        }
    }
}
