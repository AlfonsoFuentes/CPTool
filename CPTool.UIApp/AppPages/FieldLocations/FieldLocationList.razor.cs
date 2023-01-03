using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.AppPages.UnitaryPrizes;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.FieldLocations
{
    public partial class FieldLocationList
    {
        [Inject]
        public IFieldLocationService Service { get; set; }

        List<CommandFieldLocation> Elements = new();
        CommandFieldLocation SelectedItem = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowTableDialog(CommandFieldLocation model)
        {

            var result = await DialogService.OpenAsync<FieldLocationDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandFieldLocation toDelete)
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
