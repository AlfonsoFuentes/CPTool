namespace CPTool.Application.Contracts.Persistence
{
    public interface IRepositoryMWOItem : IRepository<MWOItem>
    {
        Task<MWOItem> GetMWOItemIdAsync(int id);
    }
}
