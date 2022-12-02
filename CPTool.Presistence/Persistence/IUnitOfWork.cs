using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Persistence.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
        IRepositoryPipeAccesory RepositoryPipeAccesory { get; }
        IRepositoryMWO RepositoryMWO { get; }
        IRepositoryMWOItem RepositoryMWOItem { get; }

        IRepositoryBrandSupplier RepositoryBrandSupplier { get; }
        IRepositoryBrand RepositoryBrand { get; }
        IRepositorySupplier RepositorySupplier { get; }
        IRepositoryEquipmentItem RepositoryEquipmentItem { get; }
        IRepositoryInstrumentItem RepositoryInstrumentItem { get; }
        IRepositoryPipingItem RepositoryPipingItem { get; }

        void Reset();
    }
}
