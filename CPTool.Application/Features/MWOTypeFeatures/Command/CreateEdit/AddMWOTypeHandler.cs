namespace CPTool.Application.Features.MMOTypeFeatures.CreateEdit
{
    internal class AddMWOTypeHandler :AddBaseHandler<AddMWOType, MWOType>, IRequestHandler<AddMWOType, Result<int>>
    {
       
        public AddMWOTypeHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddMWOType> logger):
            base(unitofwork, mapper, emailService, logger) { }
        

      
    }

}
