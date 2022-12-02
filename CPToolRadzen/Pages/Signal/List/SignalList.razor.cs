
using CPTool.Application.Features.SignalsFeatures.CreateEdit;

using CPToolRadzen.Pages.Signal.Dialog;


namespace CPToolRadzen.Pages.Signal.List
{
    public partial class SignalList : BaseTableTemplate<EditSignal>
    {

        EditMWO Parent => RadzenTables.MWOs.FirstOrDefault(x => x.Id == ParentId);
        public override List<EditSignal> Elements => RadzenTables.Signals.Where(x => x.MWOId == ParentId).ToList();

        protected override void OnInitialized()
        {
            TableName = "Signal";

            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditSignal model)
        {
            if (model.Id == 0)
            {
                model.MWO = Parent;
            }

            var result = await DialogService.OpenAsync<SignalDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "900px", Height = "800px", Resizable = true, Draggable = true });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
