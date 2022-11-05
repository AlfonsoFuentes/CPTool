
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Query.GetList;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.Query.GetList;

namespace CPTool.NewPages.Dialogs.MWO.List
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

            if(!result.Cancelled)
            {
                GetPurchaseOrderListQuery getPurchaseOrderListQuery = new();
                GlobalTables.PurchaseOrders = await Mediator.Send(getPurchaseOrderListQuery);

                GetPurchaseOrderMWOItemListQuery getPurchaseOrderMWOItemListQuery = new();
                GlobalTables.PurchaseOrderMWOItems = await Mediator.Send(getPurchaseOrderMWOItemListQuery);

                GetMWOItemListQuery getMWOItemListQuery = new();
                GlobalTables.MWOItems = await Mediator.Send(getMWOItemListQuery);
                GetTaksListQuery getTaksListQuery = new();
                GlobalTables.Takss = await Mediator.Send(getTaksListQuery);
            }
            
        }
        async Task CreateTaskMWO()
        {
            EditTaks editTaks = new EditTaks();
            editTaks.MWO = SelectedMaster;
            editTaks.TaksType = Domain.Entities.TaksType.Manual;
            var result=await ToolDialogService.ShowTaksDialog(editTaks);
            if(!result.Cancelled)
            {
                GetTaksListQuery getTaksListQuery = new GetTaksListQuery();
                GlobalTables.Takss=await Mediator.Send(getTaksListQuery);
            }
        }
      

        void GoToUserRequirmentPage()
        {
            Navigation.NavigateTo($"UserRequirementList/{SelectedMaster.Id}");
        }
        void GoToUserSignalList()
        {
            Navigation.NavigateTo($"SignaList/{SelectedMaster.Id}");
        }
        void GoToMWOItemList()
        {
            Navigation.NavigateTo($"MWOItemList/{SelectedMaster.Id}");
        }
    }
}
