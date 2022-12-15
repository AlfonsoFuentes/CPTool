using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;


namespace CPToolRadzen.Pages.FieldLocation.Dialog
{
    public partial class FieldLocationDialog : DialogTemplate<EditFieldLocation>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
