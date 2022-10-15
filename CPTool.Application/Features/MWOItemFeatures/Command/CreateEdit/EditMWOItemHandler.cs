namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    internal class EditMWOItemHandler : EditBaseHandler<EditMWOItem, MWOItem>, IRequestHandler<EditMWOItem, Result<int>>
    {


        public EditMWOItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditMWOItem> logger)
            : base(unitofwork, mapper, emailService, logger) { }
    }
}
