using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    public class CreateEditPurchaseOrder : EditCommand, IRequest<Result<int>>
    {
        public EditPurchaseOrder PurchaseOrder { get; set; } = new();
        public List<EditMWOItem> MWOItems { get; set; } = new();
        public EditMWOItem FirstMWOItem => MWOItems.Count > 0 ? MWOItems.First() : new();
    }
    
}
