
namespace CPTool.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repository = null!;
        private readonly TableContext _context;

        public IRepositoryMWO RepositoryMWO => _repositorymwo ??= new RepositoryMWO(_context);
        public IRepositoryMWOItem RepositoryMWOItem => _repositorymwoitem ??= new RepositoryMWOItem(_context);
        public IRepositoryBrand RepositoryBrand => _repositorybrand ??= new RepositoryBrand(_context);
        public IRepositorySupplier RepositorySupplier => _repositorysupplier ??= new RepositorySupplier(_context);

        private IRepositoryMWO _repositorymwo = null!;
        private IRepositoryMWOItem _repositorymwoitem = null!;
        private IRepositoryBrand _repositorybrand = null!;
        private IRepositorySupplier _repositorysupplier = null!;
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

       
    }
}
