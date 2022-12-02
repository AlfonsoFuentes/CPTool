
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;


namespace CPToolRadzen.Pages.SignalType.Dialog
{
    public partial class SignalTypeDialog : DialogTemplate<EditSignalType>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.SignalTypes : RadzenTables.SignalTypes.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
