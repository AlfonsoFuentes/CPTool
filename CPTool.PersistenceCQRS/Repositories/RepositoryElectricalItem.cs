namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryElectricalItem : CommandRepository<ElectricalItem>, IRepositoryElectricalItem
    {
        public RepositoryElectricalItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
