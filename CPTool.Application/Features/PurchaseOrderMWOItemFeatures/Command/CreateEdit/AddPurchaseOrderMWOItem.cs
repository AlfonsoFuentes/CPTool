





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    public class AddPurchaseOrderMWOItem : AddCommand
    {
        public int? PurchaseOrderId { get; set; }

        public int? MWOItemId { get; set; }
    }
}
