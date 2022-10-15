namespace CPTool.Application.Features.MWOFeatures.CreateEdit
{
    internal class AddMWOHandler : AddBaseHandler<AddMWO, MWO>, IRequestHandler<AddMWO, Result<int>>
    {


        public AddMWOHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddMWO> logger)
            : base(unitofwork, mapper, emailService, logger) { }
    }
}
