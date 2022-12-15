using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPToolRadzen.Pages.DownPayment.Dialog;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace CPToolRadzen.Pages.DownPayment.List
{
    public partial class DownPaymentList : TableTemplate<EditDownPayment>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.DownPayments = await CommandQuery.GetAll();
            Parent = await QueryPurchaseOrder.GetById(ParentId);
           
            TableName = "Downpayment";
        }
        EditPurchaseOrder Parent = new();
        protected override void OnInitialized()
        {
            TableName = "Downpayment";
     
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditDownPayment model)
        {
            if(model.Id==0)
            {
                model.PurchaseOrder = Parent;
            }

            var result = await DialogService.OpenAsync<DownPaymentDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
