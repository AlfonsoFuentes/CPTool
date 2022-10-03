

namespace CPTool.Implementations
{
    //public class UnitOfWork : IUnitOfWork
    //{

    //    private readonly TableContext _dbContext;

      


    //    public UnitOfWork(TableContext dbContext)
    //    {
    //        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    //    }

     

    //    public async Task<IResult<int>> Commit(CancellationToken cancellationToken)
    //    {
    //        int result = 0;
    //        try
    //        {
    //            var changetracker = _dbContext.ChangeTracker.DebugView.ShortView;
    //            result = await _dbContext.SaveChangesAsync(cancellationToken);
    //            changetracker = _dbContext.ChangeTracker.DebugView.ShortView;

    //        }
    //        catch (Exception ex)
    //        {
    //            string exm = ex.Message;
    //            return await Result<int>.FailAsync(ex.Message);
    //        }


    //        return await Result<int>.SuccessAsync(result, "Updated");
    //    }

     

       

    //}
}
