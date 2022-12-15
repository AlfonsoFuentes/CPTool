using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.Gaskets.Dialog
{
    public partial class GasketsDialog : DialogTemplate<EditGasket>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
