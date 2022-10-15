namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    internal class EditPurchaseOrderMWOItemHandler : EditBaseHandler<EditPurchaseOrderMWOItem, PurchaseOrderMWOItem>, IRequestHandler<EditPurchaseOrderMWOItem, Result<int>>
    {

        public EditPurchaseOrderMWOItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditPurchaseOrderMWOItem> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }

    }
}
