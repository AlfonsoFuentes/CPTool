namespace CPTool.Application.Features.ConnectionTypeFeatures.CreateEdit
{
    internal class AddConnectionTypeHandler :AddBaseHandler<AddConnectionType,ConnectionType>, IRequestHandler<AddConnectionType, Result<int>>
    {
      

        public AddConnectionTypeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddConnectionType> logger)
             : base(unitofwork, mapper, emailService, logger)
        {
           
        }

        
    }
}
