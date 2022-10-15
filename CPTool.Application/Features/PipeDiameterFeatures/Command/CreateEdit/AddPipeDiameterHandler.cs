namespace CPTool.Application.Features.PipeDiameterFeatures.CreateEdit
{
    internal class AddPipeDiameterHandler :AddBaseHandler<AddPipeDiameter, PipeDiameter>, IRequestHandler<AddPipeDiameter, Result<int>>
    {
      

        public AddPipeDiameterHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddPipeDiameter> logger)
        :base(unitofwork, mapper, emailService, logger) { }

       
    }

}
