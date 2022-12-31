

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryElectricalBox : CommandRepository<ElectricalBox>, IRepositoryElectricalBox
    {
        public RepositoryElectricalBox(TableContext dbcontext) : base(dbcontext)
        {
        }
        
    }
}
