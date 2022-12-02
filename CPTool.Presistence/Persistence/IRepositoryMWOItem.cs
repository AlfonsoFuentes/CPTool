namespace CPTool.Persistence.Persistence
{
    public interface IRepositoryMWOItem : IRepository<MWOItem>
    {
        Task<MWOItem> GetMWOItemIdAsync(int id);
    }
}
