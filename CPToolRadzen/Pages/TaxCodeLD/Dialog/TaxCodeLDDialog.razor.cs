
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;


namespace CPToolRadzen.Pages.TaxCodeLD.Dialog
{
    public partial class TaxCodeLDDialog : DialogTemplate<EditTaxCodeLD>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
