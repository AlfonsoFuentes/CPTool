global using CPTool.Persistence.Persistence;


namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryDeviceFunction : CommandRepository<DeviceFunction>, IRepositoryDeviceFunction
    {
        public RepositoryDeviceFunction(TableContext dbcontext) : base(dbcontext)
        {
        }
        
    }
}
