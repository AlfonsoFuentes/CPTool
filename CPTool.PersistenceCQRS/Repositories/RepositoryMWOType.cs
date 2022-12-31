

using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMWOType : CommandRepository<MWOType>, IRepositoryMWOType
    {
        public RepositoryMWOType(TableContext dbcontext) : base(dbcontext)
        {
        }

       
    }
}
