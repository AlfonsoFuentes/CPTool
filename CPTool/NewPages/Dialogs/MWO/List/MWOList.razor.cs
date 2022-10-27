
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Query.GetList;

namespace CPTool.NewPages.Dialogs.MWO.List
{
    public partial class MWOList
    {
        [Inject]
        public IMediator mediator { get; set; }
        EditMWO SelectedMaster { get; set; } = new();
        EditMWOItem SelectedDetail { get; set; } = new();
       
        async Task AddPurchaseOrder()
        {
            CreateEditPurchaseOrder CreatePurchaseOrder = new CreateEditPurchaseOrder();
            CreatePurchaseOrder.PurchaseOrder.MWO = SelectedMaster;
            

            var result=await ToolDialogService.ShowPurchaseOrderDialog(CreatePurchaseOrder);

            if(!result.Cancelled)
            {
                GetPurchaseOrderListQuery getPurchaseOrderListQuery = new();
                GlobalTables.PurchaseOrders = await mediator.Send(getPurchaseOrderListQuery);

                GetPurchaseOrderMWOItemListQuery getPurchaseOrderMWOItemListQuery = new();
                GlobalTables.PurchaseOrderMWOItems = await mediator.Send(getPurchaseOrderMWOItemListQuery);

                GetMWOItemListQuery getMWOItemListQuery = new();
                GlobalTables.MWOItems = await mediator.Send(getMWOItemListQuery);
            }
            
        }


      
        
    }
}
