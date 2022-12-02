using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.Query.GetList;
using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.Query.GetList;
using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPTool.Services;
using CPToolRadzen.Pages.DownPayment.Dialog;
using CPToolRadzen.Pages.EquipmentType.Dialog;
using CPToolRadzen.Pages.PurchaseOrder.Dialog;
using CPToolRadzen.Services;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.PurchaseOrder.List
{
    public partial class PurchaserOrderByMWO : BaseTableTemplate<EditPurchaseOrder>
    {

        [Inject]
        public ICommandQuery<EditDownPayment> DownpaymentQuery { get; set; }
        [Inject]
        public ICommandQuery<EditTaks> TaksQuery { get; set; }
        public override List<EditPurchaseOrder> Elements => RadzenTables.PurchaseOrders.Where(x => x.MWOId == ParentId).ToList();

        EditMWO Parent => RadzenTables.MWOs.FirstOrDefault(x => x.Id == ParentId);

    
     
        protected override void OnInitialized()
        {

            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditPurchaseOrder model)
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
            model.PurchaseOrder = Selected;
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
