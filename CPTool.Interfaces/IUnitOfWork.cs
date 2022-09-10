namespace CPTool.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepository<T> Repository<T>()  where T : IAuditableEntity;

        Task<int> Commit(CancellationToken cancellationToken);

        Task<IResult<int>> CommitAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
    }
}
