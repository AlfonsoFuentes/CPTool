namespace CPTool.Application.Features.GasketsFeatures.CreateEdit
{
    internal class GasketHandler : AddEditBaseHandler<AddGasket,EditGasket, Gasket>, IRequestHandler<EditGasket, Result<int>>
    {


        public GasketHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditGasket> logger) 
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}