namespace CPTool.Application.Features.WireFeatures.CreateEdit
{
    internal class WireHandler : AddEditBaseHandler<AddWire,EditWire, Wire>, IRequestHandler<EditWire, Result<int>>
    {


        public WireHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditWire> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
