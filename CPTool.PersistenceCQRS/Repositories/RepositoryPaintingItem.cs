namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPaintingItem : CommandRepository<PaintingItem>, IRepositoryPaintingItem
    {
        public RepositoryPaintingItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
