using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;

using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.ConnectionTypes
{
    public partial class ConnectionTypesList
    {
        [Inject]
        public IConnectionTypeService Service { get; set; }

        List<CommandConnectionType> Elements = new();
        CommandConnectionType SelectedItem = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowTableDialog(CommandConnectionType model)
        {

            var result = await DialogService.OpenAsync<ConnectionTypesDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandConnectionType toDelete)
        {
            
            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                SelectedItem = new();
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
