namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryPropertySpecification : CommandRepository<PropertySpecification>, IRepositoryPropertySpecification
    {


        public RepositoryPropertySpecification(TableContext dbcontext) : base(dbcontext)
        {

          
              
        }


    }
}
