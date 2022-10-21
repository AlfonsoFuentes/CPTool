namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    internal class PurchaseOrderMWOItemHandler : AddEditBaseHandler<AddPurchaseOrderMWOItem,EditPurchaseOrderMWOItem, PurchaseOrderMWOItem>, IRequestHandler<EditPurchaseOrderMWOItem, Result<int>>
    {

        public PurchaseOrderMWOItemHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditPurchaseOrderMWOItem> logger)
            : base(unitofwork, mapper,  logger)
        {

        }

    }
}
