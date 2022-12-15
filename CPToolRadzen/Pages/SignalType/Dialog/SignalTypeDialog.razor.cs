
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;


namespace CPToolRadzen.Pages.SignalType.Dialog
{
    public partial class SignalTypeDialog : DialogTemplate<EditSignalType>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
