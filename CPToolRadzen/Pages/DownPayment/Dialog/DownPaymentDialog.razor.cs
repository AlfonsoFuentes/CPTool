using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.DownPayment.Dialog
{
    public partial class DownPaymentDialog : DialogTemplate<EditDownPayment>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.DownPayments : RadzenTables.DownPayments.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
