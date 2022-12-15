
using CPTool.Application.Features.SignalsFeatures.CreateEdit;

using CPToolRadzen.Pages.Signal.Dialog;


namespace CPToolRadzen.Pages.Signal.List
{
    public partial class SignalList : TableTemplate<EditSignal>
    {

        EditMWO Parent = new();

        protected override async Task OnInitializedAsync()
        {
            Parent = await QueryMWO.GetById(ParentId);
            RadzenTables.Signals = await CommandQuery.GetAll();
           
            TableName = "Signal";

            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditSignal model)
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
