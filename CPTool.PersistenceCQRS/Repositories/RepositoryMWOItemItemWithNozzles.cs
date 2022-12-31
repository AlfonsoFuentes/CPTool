namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryMWOItemWithNozzles : CommandRepository<MWOItem>, IRepositoryMWOItemWithNozzles
    {
        public RepositoryMWOItemWithNozzles(TableContext dbcontext) : base(dbcontext)
        {


            QueryList = QueryList
                .Include(x=>x.MWO)
                .Include(x=>x.Chapter)
                .Include(x => x.EquipmentItem!).ThenInclude(x=>x.Nozzles!).ThenInclude(y=>y.ConnectedTo!)
                .Include(x => x.InstrumentItem!).ThenInclude(x => x.Nozzles!).ThenInclude(y => y.ConnectedTo!)
                .Include(x => x.PipingItem!).ThenInclude(x => x.Nozzles!).ThenInclude(y => y.ConnectedTo!)

                    ;

            QueryDialog = QueryDialog

                 .Include(x => x.MWO)
                 .Include(x => x.Chapter)
                .Include(x => x.EquipmentItem!).ThenInclude(x => x.Nozzles!).ThenInclude(y => y.ConnectedTo!)
                .Include(x => x.InstrumentItem!).ThenInclude(x => x.Nozzles!).ThenInclude(y => y.ConnectedTo!)
                .Include(x => x.PipingItem!).ThenInclude(x => x.Nozzles!).ThenInclude(y => y.ConnectedTo!)


                    ;
        }

    }
}

