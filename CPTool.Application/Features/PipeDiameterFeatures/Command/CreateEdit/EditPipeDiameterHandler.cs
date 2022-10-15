namespace CPTool.Application.Features.PipeDiameterFeatures.CreateEdit
{
    internal class EditPipeDiameterHandler : EditBaseHandler<EditPipeDiameter, PipeDiameter>, IRequestHandler<EditPipeDiameter, Result<int>>
    {


        public EditPipeDiameterHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditPipeDiameter> logger)
        : base(unitofwork, mapper, emailService, logger) { }


    }

}
