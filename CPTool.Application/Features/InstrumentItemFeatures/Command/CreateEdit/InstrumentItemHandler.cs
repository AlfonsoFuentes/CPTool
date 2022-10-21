namespace CPTool.Application.Features.InstrumentItemFeatures.CreateEdit
{
    internal class InstrumentItemHandler : AddEditBaseHandler<AddInstrumentItem,EditInstrumentItem, InstrumentItem>, IRequestHandler<EditInstrumentItem, Result<int>>
    {


        public InstrumentItemHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditInstrumentItem> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }

}
