


namespace CPTool.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repository = null!;
        private readonly TableContext _context;

        public IRepositoryPipeAccesory RepositoryPipeAccesory => _repositorypipeaccesory ??= new RepositoryPipeAccesory(_context);
        public IRepositoryMWO RepositoryMWO => _repositorymwo ??= new RepositoryMWO(_context);
        public IRepositoryMWOItem RepositoryMWOItem => _repositorymwoitem ??= new RepositoryMWOItem(_context);
        public IRepositoryBrand RepositoryBrand => _repositorybrand ??= new RepositoryBrand(_context);
        public IRepositoryBrandSupplier RepositoryBrandSupplier => _repositorybrandsupplier ??= new RepositoryBrandSupplier(_context);
        public IRepositorySupplier RepositorySupplier => _repositorysupplier ??= new RepositorySupplier(_context);
        public IRepositoryEquipmentItem RepositoryEquipmentItem => _repositoryEquipmentItem ??= new RepositoryEquipmentItem(_context);
        public IRepositoryInstrumentItem RepositoryInstrumentItem => _repositoryInstrumentItem ??= new RepositoryInstrumentItem(_context);
        public IRepositoryPipingItem RepositoryPipingItem => _repositoryPipingItem ??= new RepositoryPipingItem(_context);

        private IRepositoryMWO _repositorymwo = null!;
        private IRepositoryMWOItem _repositorymwoitem = null!;
        private IRepositoryBrand _repositorybrand = null!;
        private IRepositorySupplier _repositorysupplier = null!;
        private IRepositoryEquipmentItem _repositoryEquipmentItem = null!;
        private IRepositoryInstrumentItem _repositoryInstrumentItem = null!;
        private IRepositoryPipingItem _repositoryPipingItem = null!;
        private IRepositoryBrandSupplier _repositorybrandsupplier = null!;
        private IRepositoryPipeAccesory _repositorypipeaccesory = null!;
        public UnitOfWork(TableContext context)
        {

            _context = context;
        }
       
        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repository == null)
            {
                _repository = new();
            }
            var type = typeof(TEntity);
            if (!_repository.ContainsKey(type))
            {
                var repositorytype = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositorytype.MakeGenericType(typeof(TEntity)), _context);
                _repository.Add(type, repositoryInstance);
            }
            var response = (IRepository<TEntity>)_repository[type]!;
            return response;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Reset()
        {
           _context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
        }
    }
}
