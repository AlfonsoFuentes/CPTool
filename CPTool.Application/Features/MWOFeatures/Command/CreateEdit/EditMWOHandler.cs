namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    internal class EditMWOHandler : EditBaseHandler<EditMWO, MWO>, IRequestHandler<EditMWO, Result<int>>
    {


        public EditMWOHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditMWO> logger)
            : base(unitofwork, mapper, emailService, logger) { }
    }
}
