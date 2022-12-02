using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPToolRadzen.Pages.DownPayment.Dialog;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace CPToolRadzen.Pages.DownPayment.List
{
    public partial class DownPaymentList : BaseTableTemplate<EditDownPayment>
    {

        public override List<EditDownPayment> Elements => RadzenTables.DownPayments;

        EditPurchaseOrder Parent => RadzenTables.PurchaseOrders.FirstOrDefault(x => x.Id == ParentId);
        protected override void OnInitialized()
        {
            TableName = "Downpayment";
     
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditDownPayment model)
        {

            var result = await DialogService.OpenAsync<DownPaymentDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
