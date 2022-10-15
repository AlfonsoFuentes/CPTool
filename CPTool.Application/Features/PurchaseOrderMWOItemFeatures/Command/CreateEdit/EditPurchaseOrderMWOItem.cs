using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    public class EditPurchaseOrderMWOItem : EditCommand, IRequest<Result<int>>
    {
        //public int? PurchaseOrderId => PurchaseOrderCommand?.Id == 0 ? null : PurchaseOrderCommand?.Id;

        public EditPurchaseOrder? PurchaseOrder { get; set; }

        //public int? MWOItemId => MWOItemCommand?.Id == 0 ? null : MWOItemCommand?.Id;
        public EditMWOItem? MWOItem { get; set; }

    }
}
