using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Entities;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.ControlLoops
{
    public partial  class ControlLoopsList
    {
        [Inject]
        public IControlLoopService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandControlLoop> Elements = new();
        CommandControlLoop SelectedItem = new();
        CommandMWO MWO = new();
        [Parameter]
        public int MWOId { get; set; }
        
        public async Task UpdateTable()
        {
            MWO = await MWOService.GetById(MWOId);
            Elements = await Service.GetAll(MWOId);
            StateHasChanged();
        }
        async Task<bool> ShowTableDialog(CommandControlLoop model)
        {
            if(model.Id== 0) {

                model.MWO = MWO;
            }
            var result = await DialogService.OpenAsync<ControlLoopsDialog>(model.Id == 0 ? $"Add new Control Loop" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },  
                  new DialogOptions() { Width = "1200px", Height = "850px", Resizable = true, Draggable = true });
            if (result == null) return false;

            if ((bool)result)
            {
                Elements = await Service.GetAll(MWOId);
                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandControlLoop toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                SelectedItem = new();
                Elements = await Service.GetAll(MWOId);
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
