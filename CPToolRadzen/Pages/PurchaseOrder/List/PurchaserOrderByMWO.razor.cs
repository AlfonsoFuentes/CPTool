using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;

using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Generic;
using CPToolRadzen.Pages.DownPayment.Dialog;

using CPToolRadzen.Pages.PurchaseOrder.Dialog;

using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.PurchaseOrder.List
{
    public partial class PurchaserOrderByMWO : TableTemplate<EditPurchaseOrder>
    {

        [Inject]
        public ICommandQuery<EditDownPayment> DownpaymentQuery { get; set; }
        [Inject]
        public ICommandQuery<EditTaks> TaksQuery { get; set; }

        EditMWO Parent = new();



        protected override async Task OnInitializedAsync()
        {
            RadzenTables.PurchaseOrders = await CommandQuery.GetAll();
            Parent = await QueryMWO.GetById(ParentId);

            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditPurchaseOrder model)
        {
            if (model.Id == 0)
            {
                model.MWO = Parent;


            }
            var result = await DialogService.OpenAsync<PurchaseOrderDialog>
                (model.Id == 0 ? $"Add new purchase order to {Parent.Name}" : $"Edit {model.Name}", 
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });
            if (result == null) return false;
            return (bool)result;
        }
        public async Task<bool> ShowDownPaymentDialog(EditDownPayment model)
        {

            var result = await DialogService.OpenAsync<DownPaymentDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });
            if (result == null) return false;
            return (bool)result;

        }
        async Task AddDownPayment()
        {
            EditDownPayment model = new();
            model.PurchaseOrder = SelectedItem;
            var result = await ShowDownPaymentDialog(model);
            if(result)
            {
                RadzenTables.DownPayments = await DownpaymentQuery.GetAll();
                RadzenTables.Takss = await TaksQuery.GetAll();
            }
            

        }
        void CreateTaskMWO()
        {

        }
    }
}
