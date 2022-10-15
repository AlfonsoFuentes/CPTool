namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    internal class AddMWOItemHandler : AddBaseHandler<AddMWOItem, MWOItem>, IRequestHandler<AddMWOItem, Result<int>>
    {


        public AddMWOItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddMWOItem> logger)
            : base(unitofwork, mapper, emailService, logger) { }
    }
}
