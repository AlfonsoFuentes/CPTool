
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
using CPTool.UIApp.AppPages.MWOItems;
using CPTool.UIApp.AppPages.PurchaseOrders.Dialog;

namespace CPTool.UIApp.AppPages.PurchaseOrders
{
    public partial class PurchaseOrderList
    {
       
        [Inject]
        public IPurchaseOrderService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandPurchaseOrder> Elements { get; set; } = new();
        CommandPurchaseOrder SelectedItem = new();

        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll(0);
           
        }
      

        bool DisableDownpayment => SelectedItem.Id == 0 || (int)SelectedItem.PurchaseOrderStatus > (int)PurchaseOrderApprovalStatus.Created;
        Task<bool> ShowTableDialog(CommandPurchaseOrder model)
        {
            //if (model.Id == 0)
            //{
            //    NavigationManager.NavigateTo($"/PurchaseOrderDialog/{DialogParent.Model.Id}");
            //}
            //else
            //{
            //    NavigationManager.NavigateTo($"/PurchaseOrderDialog/{model..Model.Id}/{model.Id}");
            //}


            return Task.FromResult(true);

        }

        //async Task<bool> ShowTableDialog(CommandPurchaseOrder model)
        //{


        //    var result = await DialogService.OpenAsync<PurchaseOrderDialog>( $"Edit {model.PONumber}",
        //          new Dictionary<string, object> { { "Model", model } },
        //       new DialogOptions() { Width = "1200px", Height = "700px", Resizable = true, Draggable = true });


        //    if (result == null) return false;

        //    if ((bool)result)
        //    {
        //        Elements = await Service.GetAll(0);

        //        StateHasChanged();
        //    }
        //    return (bool)result;

        //}
        async Task<bool> Delete(CommandPurchaseOrder toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll(0);

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
            Elements = await Service.GetAllWithSearch( searched);

        }
    }
}
