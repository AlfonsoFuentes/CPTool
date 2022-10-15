namespace CPTool.Application.Features.PipingItemFeatures.CreateEdit
{
    internal class EditPipingItemHandler : EditBaseHandler<EditPipingItem, PipingItem>, IRequestHandler<EditPipingItem, Result<int>>
    {

        public EditPipingItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditPipingItem> logger)
        : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
