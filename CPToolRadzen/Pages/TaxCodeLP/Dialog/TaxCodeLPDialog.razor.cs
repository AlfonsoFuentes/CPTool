
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;


namespace CPToolRadzen.Pages.TaxCodeLP.Dialog
{
    public partial class TaxCodeLPDialog : DialogTemplate<EditTaxCodeLP>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.TaxCodeLPs : RadzenTables.TaxCodeLPs.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
