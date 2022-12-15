
using CPTool.Application.Features.WireFeatures.CreateEdit;


namespace CPToolRadzen.Pages.Wire.Dialog
{
    public partial class WireDialog : DialogTemplate<EditWire>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
