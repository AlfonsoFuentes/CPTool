
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using CPTool.UIApp.AppPages.DownPayments;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Radzen;
using CPTool.UIApp.AppPages.MWOItemsNew.List;

namespace CPTool.UIApp.AppPages.MWOItemsNew
{
    public partial class PurchaseOrderListMWOItem
    {
        [CascadingParameter]
        public TabsMWOItems DialogParent { get; set; }
        [Inject]
        public IPurchaseOrderService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandPurchaseOrder> Elements => DialogParent.MWOItemListData.PurchaseOrder;
        CommandPurchaseOrder SelectedItem = new();
       

        CommandMWO Parent => DialogParent.MWOItemListData.MWO;

        bool DisableDownpayment => SelectedItem.Id == 0 || (int)SelectedItem.PurchaseOrderStatus > (int)PurchaseOrderApprovalStatus.Created;

        Task<bool> ShowTableDialog(CommandPurchaseOrder model)
        {
            if (model.Id == 0)
            {
                NavigationManager.NavigateTo($"/PurchaseOrderDialog/{Parent.Id}");
            }
            else
            {
                NavigationManager.NavigateTo($"/PurchaseOrderDialog/{Parent.Id}/{model.Id}");
            }


            return Task.FromResult(true);

        }
        //async Task<bool> ShowTableDialog(CommandPurchaseOrder model)
        //{
        //    if (model.Id == 0)
        //    {

        //        model.MWO = Parent;
        //    }

        //    var result = await DialogService.OpenAsync<PurchaseOrderDialog>(model.Id == 0 ? $"Add new Purchaser to {Parent.Name}" : $"Edit {model.PONumber}",
        //          new Dictionary<string, object> { { "Model", model } },
        //       new DialogOptions() { Width = "1200px", Height = "700px", Resizable = true, Draggable = true });


        //    if (result == null) return false;

        //    if ((bool)result)
        //    {
        //        DialogParent.MWOItemListData.PurchaseOrder = await Service.GetAll(Parent.Id);

        //        StateHasChanged();
        //    }
        //    return (bool)result;

        //}
        async Task<bool> Delete(CommandPurchaseOrder toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                DialogParent.MWOItemListData.PurchaseOrder = await Service.GetAll(Parent.Id);

                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
        public async Task<bool> ShowDownPaymentDialog(CommandDownPayment model)
        {
            if (model.Id == 0)
            {
                model.PurchaseOrder = SelectedItem;
            }
            var result = await DialogService.OpenAsync<DownPaymentDialog>(model.Id == 0 ? $"Add new Downpyament to {SelectedItem.PONumber}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });
            if (result == null) return false;
            return (bool)result;

        }
        async Task AddDownPayment()
        {
            CommandDownPayment model = new();

            var result = await ShowDownPaymentDialog(model);



        }
        async Task SearchChanged(string searched)
        {
            DialogParent.MWOItemListData.PurchaseOrder = await Service.GetAllWithSearch( searched);

        }
    }
}
