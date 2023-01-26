using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.AppPages.UserRequirments;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using CPTool.UIApp.AppPages.MWOItemsNew.List;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using Autofac.Core;

namespace CPTool.UIApp.AppPages.Signals
{
    public partial class SignalsList
    {
        [CascadingParameter]
        public TabsMWOItems DialogParent { get; set; }

        [Inject]
        public ISignalService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }

        List<CommandSignal> Elements => DialogParent.MWOItemListData.Signals;
        CommandSignal SelectedItem = new();

        CommandMWO Parent => DialogParent.MWOItemListData.MWO;

       
        async Task<bool> ShowTableDialog(CommandSignal model)
        {
            if(model.Id==0)
            {
                model.MWO = Parent;
            }

            var result = await DialogService.OpenAsync<SignalsDialog>(model.Id == 0 ? $"Add new Signal to {model.MWOName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "800px", Height = "850px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {
                DialogParent.MWOItemListData.Signals = await Service.GetAll(Parent.Id);

                StateHasChanged();
            }
            return (bool)result;

        }
        async Task<bool> Delete(CommandSignal toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                DialogParent.MWOItemListData.Signals = await Service.GetAll(Parent.Id);

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
