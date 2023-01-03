

namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositorySignal : CommandRepository<Signal>, IRepositorySignal
    {
        public RepositorySignal(TableContext dbcontext) : base(dbcontext)
        {
            QueryList = QueryList
                    .Include(x => x.MWO!)
                     .Include(x => x.Wire!)
                      .Include(x => x.FieldLocation!)
                       .Include(x => x.ElectricalBox!)
                          .Include(x => x.MWOItem!).ThenInclude(x => x.Chapter)
                            .Include(x => x.SignalType!)
                   .Include(x => x.SignalModifier!);

            QueryDialog = QueryDialog

                    .Include(x => x.MWO!)
                     .Include(x => x.Wire!)
                      .Include(x => x.FieldLocation!)
                       .Include(x => x.ElectricalBox!)
                        .Include(x => x.MWOItem!).ThenInclude(x=>x.Chapter)
                            .Include(x => x.SignalType!)
                   .Include(x => x.SignalModifier!);
        }
       
     
    }
}
