





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    public class AddPurchaseOrderMWOItem : AddCommand, IRequest<Result<int>>
    {
        public int? PurchaseOrderId => PurchaseOrderCommand?.Id == 0 ? null : PurchaseOrderCommand?.Id;

        public EditPurchaseOrder? PurchaseOrderCommand { get; set; }

        public int? MWOItemId => MWOItemCommand?.Id == 0 ? null : MWOItemCommand?.Id;
        public EditMWOItem? MWOItemCommand { get; set; }

    }
}
