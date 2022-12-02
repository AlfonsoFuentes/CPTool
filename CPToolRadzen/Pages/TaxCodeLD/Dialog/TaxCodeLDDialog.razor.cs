
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;


namespace CPToolRadzen.Pages.TaxCodeLD.Dialog
{
    public partial class TaxCodeLDDialog : DialogTemplate<EditTaxCodeLD>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.TaxCodeLDs : RadzenTables.TaxCodeLDs.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
