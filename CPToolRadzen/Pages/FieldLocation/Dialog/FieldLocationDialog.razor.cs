using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;


namespace CPToolRadzen.Pages.FieldLocation.Dialog
{
    public partial class FieldLocationDialog : DialogTemplate<EditFieldLocation>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.FieldLocations : RadzenTables.FieldLocations.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
