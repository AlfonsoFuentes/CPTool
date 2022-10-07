using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Application.Contracts.Persistence
{
    public interface IRepositoryMWO :IRepository<MWO>
    {
        Task<MWO> GetMWO_ItemsIdAsync(int id);
        Task<MWO> GetMWO_PurchaseOrderIdAsync(int id);
    }
}
