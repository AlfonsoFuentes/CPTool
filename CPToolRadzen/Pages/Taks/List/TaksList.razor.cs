
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

using CPToolRadzen.Pages.Taks.Dialog;


namespace CPToolRadzen.Pages.Taks.List
{
    public partial class TaksList : TableTemplate<EditTaks>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.Takss = await CommandQuery.GetAll();
            TableName = "Task";
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditTaks model)
        {

            var result = await DialogService.OpenAsync<TaksDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
