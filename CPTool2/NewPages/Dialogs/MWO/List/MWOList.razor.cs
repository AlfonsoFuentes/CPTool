
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;

namespace CPTool2.NewPages.Dialogs.MWO.List
{
    public partial class MWOList
    {

        EditMWO SelectedMaster { get; set; } = new();
        EditMWOItem SelectedDetail { get; set; } = new();
       
        async Task AddPurchaseOrder()
        {
            CreateEditPurchaseOrder CreatePurchaseOrder = new CreateEditPurchaseOrder();
            CreatePurchaseOrder.PurchaseOrder.MWO = SelectedMaster;
            

            var result=await ToolDialogService.ShowPurchaseOrderDialog(CreatePurchaseOrder);


        }


      
        
    }
}
