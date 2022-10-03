namespace CPTool.Interfaces
{
    public interface IUnitOfWork 
    {
       

        Task<IResult<int>> Commit(CancellationToken cancellationToken);

       
    }
}
