using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.UnitaryPrizes
{
    public partial class UnitaryPrizesList
    {
        [Inject]
        public IUnitaryBasePrizeService Service { get; set; }

        List<CommandUnitaryBasePrize> Elements = new();
        CommandUnitaryBasePrize SelectedItem = new();
        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowTableDialog(CommandUnitaryBasePrize model)
        {

            var result = await DialogService.OpenAsync<UnitaryPrizesDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandUnitaryBasePrize toDelete)
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
