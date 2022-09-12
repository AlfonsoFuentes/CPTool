﻿namespace CPTool.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TableContext _dbContext;

        private Hashtable? _repositories;


        public UnitOfWork(TableContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : IAuditableEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type]!;
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IResult<int>> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            int result = 0;
            try
            {
                 result = await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch(Exception ex)
            {
                string exm = ex.Message;
                return await Result<int>.FailAsync( "Saving error");
            }


            return await Result<int>.SuccessAsync(result, "Updated"); 
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        

       
    }
}