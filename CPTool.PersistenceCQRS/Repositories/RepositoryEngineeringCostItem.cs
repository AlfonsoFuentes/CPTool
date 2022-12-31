namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryEngineeringCostItem : CommandRepository<EngineeringCostItem>, IRepositoryEngineeringCostItem
    {
        public RepositoryEngineeringCostItem(TableContext dbcontext) : base(dbcontext)
        {
        }

    }
}
