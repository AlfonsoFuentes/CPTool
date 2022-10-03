namespace CPTool.GenericSample
{
    public class UnitOfWorkGenericSample : IUnitOfWorkGenericSample
    {
        public UnitOfWorkGenericSample(IRepository repository)
        {
            Repository = repository;
        }
        public IRepository Repository { get; }
    }
}