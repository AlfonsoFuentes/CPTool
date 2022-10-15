namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    internal class EditPurchaseOrderHandler : EditBaseHandler<EditPurchaseOrder, PurchaseOrder>, IRequestHandler<EditPurchaseOrder, Result<int>>
    {

        public EditPurchaseOrderHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditPurchaseOrder> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }

}
