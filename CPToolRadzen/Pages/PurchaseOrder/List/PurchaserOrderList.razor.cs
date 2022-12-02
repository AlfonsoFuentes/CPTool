using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPToolRadzen.Pages.DownPayment.Dialog;
using CPToolRadzen.Pages.Gaskets.Dialog;
using CPToolRadzen.Pages.PurchaseOrder.Dialog;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace CPToolRadzen.Pages.PurchaseOrder.List
{
    public partial class PurchaserOrderList : BaseTableTemplate<EditPurchaseOrder>
    {
        [Inject]
        public ICommandQuery<EditDownPayment> DownpaymentQuery { get; set; }
        [Inject]
        public ICommandQuery<EditTaks> TaksQuery { get; set; }
        public override List<EditPurchaseOrder> Elements => RadzenTables.PurchaseOrders;


        protected override void OnInitialized()
        {
            TableName = "Purchase order";
     
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditPurchaseOrder model)
        {

            var result = await DialogService.OpenAsync<PurchaseOrderDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true }); ;
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
            model.PurchaseOrder = Selected;
            var result = await ShowDownPaymentDialog(model);
            if (result)
            {
                RadzenTables.DownPayments = await DownpaymentQuery.GetAll();
                RadzenTables.Takss = await TaksQuery.GetAll();
            }


        }
    }
}
