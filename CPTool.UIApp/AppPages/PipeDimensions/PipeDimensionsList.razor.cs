using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.PipeDimensions
{
    public partial class PipeDimensionsList
    {
        [Inject]
        public IPipeDimensionService Service { get; set; }

        List<CommandPipeClass> Elements = new();
        CommandPipeClass SelectedItem = new();
        CommandPipeDiameter SelectedItemSub = new();

        protected override async Task OnInitializedAsync()
        {
            Elements = await Service.GetAll();
        }
        async Task<bool> ShowPipeClassDialog(CommandPipeClass model)
        {

            var result = await DialogService.OpenAsync<PipeClassDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> DeletePipeClass(CommandPipeClass toDelete)
        {
           
            var result = await Service.DeletePipeClass(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll();
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> ExportPipeClass(string type)
        {
            return await Service.GetFiletoExportPipeClass(type, Elements);
        }

        async Task<bool> ShowPipeDiameterDialog(CommandPipeDiameter model)
        {
            if (SelectedItem == null) return false;
            if (model.Id == 0)
            {
                model.dPipeClass = SelectedItem;
            }
            var result = await DialogService.OpenAsync<PipeDiameterDialog>(model.Id == 0 ? $"Add new MWO Type" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll();
                SelectedItem = Elements.FirstOrDefault(x => x.Id == SelectedItem.Id);
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> DeletePipeDiameter(CommandPipeDiameter toDelete)
        {
        
            var result = await Service.DeletePipeDiameter(toDelete.Id);
            if (result.Success)
            {
                Elements = await Service.GetAll();
                SelectedItem = Elements.FirstOrDefault(x => x.Id == SelectedItem.Id);
                StateHasChanged();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> ExportPipeDiameter(string type)
        {
            return await Service.GetFiletoExportPipeDiameter(type, SelectedItem.PipeDiameters);
        }
    }
}
