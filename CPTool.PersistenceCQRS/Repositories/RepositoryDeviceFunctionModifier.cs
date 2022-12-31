

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryDeviceFunctionModifier : CommandRepository<DeviceFunctionModifier>, IRepositoryDeviceFunctionModifier
    {
        public RepositoryDeviceFunctionModifier(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
