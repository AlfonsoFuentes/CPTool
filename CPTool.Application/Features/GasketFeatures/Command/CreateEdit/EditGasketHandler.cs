namespace CPTool.Application.Features.GasketsFeatures.CreateEdit
{
    internal class EditGasketHandler : EditBaseHandler<EditGasket, Gasket>, IRequestHandler<EditGasket, Result<int>>
    {


        public EditGasketHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditGasket> logger) 
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}