namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryEquipmentItem : CommandRepository<EquipmentItem>, IRepositoryEquipmentItem
    {
        public RepositoryEquipmentItem(TableContext dbcontext) : base(dbcontext)
        {
          

            QueryList = QueryList
                 
             .Include(x => x.eEquipmentType)
              .Include(x => x.eEquipmentTypeSub);
            QueryDialog = QueryDialog
              .Include(x => x.eEquipmentType)
              .Include(x => x.eEquipmentTypeSub)
              .Include(x => x.eBrand)
              .Include(x => x.eSupplier)
              .Include(x => x.eInnerMaterial)
              .Include(x => x.eOuterMaterial)
              .Include(x => x.eGasket)
              .Include(x => x.eProcessCondition)
              .Include(x => x.eProcessFluid)
              .Include(x=>x.Nozzles)
              ;
        }

    }
   
}
