using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;

using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Taks
{
    public partial class TaksList
    {
        [Inject]
        public ITaksService Service { get; set; }

        List<CommandTaks> Elements = new();
        CommandTaks SelectedItem = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowTableDialog(CommandTaks model)
        {

            var result = await DialogService.OpenAsync<TaksDialog>(model.Id == 0 ? $"Add new Task" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandTaks toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
    }
}
