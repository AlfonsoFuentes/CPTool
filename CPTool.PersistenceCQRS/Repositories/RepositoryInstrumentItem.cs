namespace CPToolCQRS.Infrastructure.Repositories
{
    public class RepositoryInstrumentItem : CommandRepository<InstrumentItem>, IRepositoryInstrumentItem
    {
        public RepositoryInstrumentItem(TableContext dbcontext) : base(dbcontext)
        {
           
            QueryList = QueryList
               
           .Include(x => x.DeviceFunction)
              .Include(x => x.DeviceFunctionModifier)
              .Include(x => x.MeasuredVariable)
              .Include(x => x.MeasuredVariableModifier)
              .Include(x => x.Readout);
            QueryDialog = QueryDialog
                 .Include(x => x.DeviceFunction)
              .Include(x => x.DeviceFunctionModifier)
              .Include(x => x.iBrand)
              .Include(x => x.iSupplier)
              .Include(x => x.MeasuredVariable)
              .Include(x => x.MeasuredVariableModifier)
              .Include(x => x.Readout)
              .Include(x => x.iProcessFluid)
              .Include(x => x.iProcessCondition)
              .Include(x => x.iOuterMaterial)
              .Include(x => x.iInnerMaterial)
              .Include(x => x.iGasket)
              .Include(x=>x.Nozzles)
              ;
        }
       
    }
   
}
