
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using CPTool.UIApp.AppPages.DownPayments;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Radzen;

namespace CPTool.UIApp.AppPages.PurchaseOrders
{
    public partial class PurchaseOrderList
    {
        [Inject]
        public IPurchaseOrderService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandPurchaseOrder> Elements = new();
        CommandPurchaseOrder SelectedItem = new();
        [Parameter]
        public int MWOId { get; set; }

        CommandMWO Parent;

        bool DisableDownpayment => SelectedItem.Id == 0 || (int)SelectedItem.PurchaseOrderStatus > (int)PurchaseOrderApprovalStatus.Created;
        protected override async Task OnInitializedAsync()
        {
            if (MWOId == 0)
                await UpdateTable();

        }
        public async Task UpdateTable()
        {
            Parent = await MWOService.GetById(MWOId);
            Elements = await Service.GetAll(MWOId);
            StateHasChanged();
        }
        async Task<bool> ShowTableDialog(CommandPurchaseOrder model)
        {
            if (model.Id == 0)
            {

                model.MWO = Parent;
            }

            var result = await DialogService.OpenAsync<PurchaseOrderDialog>(model.Id == 0 ? $"Add new Purchaser to {Parent.Name}" : $"Edit {model.PONumber}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "700px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll(MWOId);

                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandPurchaseOrder toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll(MWOId);

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
            Elements = await Service.GetAllWithSearch(MWOId, searched);

        }
    }
}
