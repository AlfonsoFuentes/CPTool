namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositorySpecification : CommandRepository<Specification>, IRepositorySpecification
    {


        public RepositorySpecification(TableContext dbcontext) : base(dbcontext)
        {
            QueryList = QueryList
                .Include(x => x.PropertySpecifications);
            QueryDialog = QueryDialog
               .Include(x => x.PropertySpecifications)
               ;
        }


    }
}
