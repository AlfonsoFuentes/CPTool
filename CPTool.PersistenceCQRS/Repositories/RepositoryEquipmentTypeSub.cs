

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryEquipmentTypeSub : CommandRepository<EquipmentTypeSub>, IRepositoryEquipmentTypeSub
    {
        public RepositoryEquipmentTypeSub(TableContext dbcontext) : base(dbcontext)
        {
          
            QueryList = QueryList
             .Include(x => x.EquipmentType);
            QueryDialog = QueryDialog
                 .Include(x => x.EquipmentType);
        }
       
    }
}
