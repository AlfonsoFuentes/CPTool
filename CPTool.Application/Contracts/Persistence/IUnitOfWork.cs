using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
       
        IRepositoryMWO RepositoryMWO { get; }
        IRepositoryMWOItem RepositoryMWOItem { get; }

        IRepositoryBrand RepositoryBrand { get; }
        IRepositorySupplier RepositorySupplier { get; }
        IRepositoryEquipmentItem RepositoryEquipmentItem { get; }
        IRepositoryInstrumentItem RepositoryInstrumentItem { get; }
        IRepositoryPipingItem RepositoryPipingItem { get; }
    }
}
