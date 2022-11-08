using CPTool.Application.Features.BrandSupplierFeatures.Query.GetById;
using CPTool.Application.Features.BrandSupplierFeatures.Query.GetList;
using CPTool.Application.Features.BrandSupplierFeatures;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    public class EditPurchaseOrderMWOItem : EditCommand, IRequest<Result<int>>
    {
       
        public bool PurchaseOrderCreated { get; set; }=false;
        public EditPurchaseOrder? PurchaseOrder { get; set; } = new();

        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;

        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public EditMWOItem? MWOItem { get; set; } = new();

    }
}
