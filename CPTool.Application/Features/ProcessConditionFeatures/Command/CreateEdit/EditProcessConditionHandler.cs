namespace CPTool.Application.Features.ProcessConditionFeatures.CreateEdit
{
    internal class EditProcessConditionHandler : EditBaseHandler<EditProcessCondition, ProcessCondition>, IRequestHandler<EditProcessCondition, Result<int>>
    {


        public EditProcessConditionHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditProcessCondition> logger)
            : base(unitofwork, mapper, emailService, logger) { }


    }
}
