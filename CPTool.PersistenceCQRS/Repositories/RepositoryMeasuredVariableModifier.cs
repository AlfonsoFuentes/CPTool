

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMeasuredVariableModifier : CommandRepository<MeasuredVariableModifier>, IRepositoryMeasuredVariableModifier
    {
        public RepositoryMeasuredVariableModifier(TableContext dbcontext) : base(dbcontext)
        {
        }
        
    }
}
