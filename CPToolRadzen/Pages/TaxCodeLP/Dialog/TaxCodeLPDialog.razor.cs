
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;


namespace CPToolRadzen.Pages.TaxCodeLP.Dialog
{
    public partial class TaxCodeLPDialog : DialogTemplate<EditTaxCodeLP>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
