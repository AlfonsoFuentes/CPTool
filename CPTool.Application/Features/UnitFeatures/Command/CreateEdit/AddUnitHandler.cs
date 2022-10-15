namespace CPTool.Application.Features.UnitFeatures.CreateEdit
{
    internal class AddUnitHandler :AddBaseHandler<AddUnit, CPTool.Domain.Entities.Unit>, IRequestHandler<AddUnit, Result<int>>
    {
       

        public AddUnitHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddUnit> logger)
            :base(unitofwork, mapper, emailService, logger) { }
        

        
    }
}
