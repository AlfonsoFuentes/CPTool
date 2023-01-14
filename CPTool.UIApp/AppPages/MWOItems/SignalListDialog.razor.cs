using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UIApp.AppPages.Signals;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class SignalListDialog
    {


        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        [Inject]
        public ISignalService Service { get; set; }
        [Inject]
        public IMWOService MWOService { get; set; }
        protected MWOItemDialogData DialogData => DialogParent.DialogData;

        List<CommandSignal> Elements = new();
        CommandSignal SelectedItem = new();

        CommandMWOItem Model => DialogParent.Model;


        protected override void OnInitialized()
        {

            Elements = Model.Signals;


        }

        async Task<bool> ShowTableDialog(CommandSignal model)
        {
            if (model.Id == 0)
            {
                model.MWO = Model.MWO;
                model.MWOItem = DialogParent.Model;
                if (model.MWOItem.Id == 0)
                {

                    Model.Signals.Add(model);
                }


            }

            var result = await DialogService.OpenAsync<SignalsDialog>(model.Id == 0 ? $"Add new Signal to {model.MWOName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
               new DialogOptions() { Width = "800px", Height = "850px", Resizable = true, Draggable = true });


            if (result == null) return false;

            if ((bool)result)
            {
                await DialogParent.UpdateModel();
                await table.RefresheTable();
                StateHasChanged();
            }
            return (bool)result;

        }

        async Task<bool> Delete(CommandSignal toDelete)
        {

            var result = await Service.Delete(toDelete.Id);
            if (result.Success)
            {
                await DialogParent.UpdateModel();

                await table.RefresheTable();
            }
            return result.Success;
        }
        async Task<ExportBaseResponse> Export(string type)
        {
            return await Service.GetFiletoExport(type, Elements);
        }
    }
}
