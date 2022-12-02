
using CPTool.Application.Features.SignalTypesFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

using CPToolRadzen.Pages.Taks.Dialog;


namespace CPToolRadzen.Pages.Taks.List
{
    public partial class TaksList : BaseTableTemplate<EditTaks>
    {

        public override List<EditTaks> Elements => RadzenTables.Takss;



        protected override void OnInitialized()
        {
            TableName = "Task";
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditTaks model)
        {

            var result = await DialogService.OpenAsync<TaksDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
