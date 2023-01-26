using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Entities;
using CPTool.InfrastructureCQRS.Services;
using CPTool.UIApp.AppPages.MWOItemsNew.List;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.ControlLoops
{
    public partial  class ControlLoopsList
    {
        [CascadingParameter]
        public TabsMWOItems DialogParent { get; set; }
        [Inject]
        public IControlLoopService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandControlLoop> Elements => DialogParent.MWOItemListData.ControlLoops;
        CommandControlLoop SelectedItem = new();
        CommandMWO Parent => DialogParent.MWOItemListData.MWO;
       
        
        
        async Task<bool> ShowTableDialog(CommandControlLoop model)
        {
            if(model.Id== 0) {

                model.MWO = Parent;
            }
            var result = await DialogService.OpenAsync<ControlLoopsDialog>(model.Id == 0 ? $"Add new Control Loop" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },  
                  new DialogOptions() { Width = "1200px", Height = "850px", Resizable = true, Draggable = true });
            if (result == null) return false;

            if ((bool)result)
            {
                DialogParent.MWOItemListData.ControlLoops = await Service.GetAll(Parent.Id);
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
                DialogParent.MWOItemListData.ControlLoops = await Service.GetAll(Parent.Id);
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
