namespace CPTool.Application.Features.ProcessConditionFeatures.CreateEdit
{
    internal class AddProcessConditionHandler :AddBaseHandler<AddProcessCondition, ProcessCondition>, IRequestHandler<AddProcessCondition, Result<int>>
    {
       

        public AddProcessConditionHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddProcessCondition> logger)
            :base(unitofwork, mapper, emailService, logger) { }

      
    }
}
