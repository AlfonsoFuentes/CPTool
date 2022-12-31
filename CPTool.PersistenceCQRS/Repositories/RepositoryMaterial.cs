

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMaterial : CommandRepository<Material>, IRepositoryMaterial
    {
        public RepositoryMaterial(TableContext dbcontext) : base(dbcontext)
        {
        }
       
    }
}
