namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    internal class AddPurchaseOrderHandler :AddBaseHandler<AddPurchaseOrder, PurchaseOrder>, IRequestHandler<AddPurchaseOrder, Result<int>>
    {
       
        public AddPurchaseOrderHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddPurchaseOrder> logger)
            :base(unitofwork, mapper, emailService, logger)
        {

        }

       
    }

}
