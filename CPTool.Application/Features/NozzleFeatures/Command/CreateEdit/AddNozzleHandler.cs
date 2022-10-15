namespace CPTool.Application.Features.NozzleFeatures.CreateEdit
{
    internal class AddNozzleHandler :AddBaseHandler<AddNozzle,Nozzle>, IRequestHandler<AddNozzle, Result<int>>
    {
        
        public AddNozzleHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddNozzle> logger)
            :base(unitofwork,mapper,emailService, logger)
        {
          
        }


    }
}
