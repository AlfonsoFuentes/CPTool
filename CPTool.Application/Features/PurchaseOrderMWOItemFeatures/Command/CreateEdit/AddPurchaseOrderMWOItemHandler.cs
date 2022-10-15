namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    internal class AddPurchaseOrderMWOItemHandler : AddBaseHandler<AddPurchaseOrderMWOItem, PurchaseOrderMWOItem>, IRequestHandler<AddPurchaseOrderMWOItem, Result<int>>
    {

        public AddPurchaseOrderMWOItemHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddPurchaseOrderMWOItem> logger)
            :base(unitofwork,mapper,emailService,logger)
        {
           
        }

    }
}
