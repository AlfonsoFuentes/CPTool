
using CPTool.Application.Features.SignalsFeatures.CreateEdit;


namespace CPToolRadzen.Pages.Signal.Dialog
{
    public partial class SignalDialog : DialogTemplate<EditSignal>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.Signals : RadzenTables.Signals.Where(x => x.Id != Model.Id).ToList();
        }
        List<EditMWOItem> MWOItems => GetMWOItems();
        List<EditMWOItem> GetMWOItems()
        {
            var result = RadzenTables.MWOItems.Where(x => x.MWOId == Model.MWOId && x.TagId != "" && x.ChapterId != 6).ToList();
            return result;

        }
    }
}
