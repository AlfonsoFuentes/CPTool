namespace CPTool.Application.Features.GasketsFeatures.CreateEdit
{
    internal class AddGasketHandler : AddBaseHandler<AddGasket, Gasket>, IRequestHandler<AddGasket, Result<int>>
    {


        public AddGasketHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddGasket> logger) : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}