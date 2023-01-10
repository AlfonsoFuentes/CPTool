

using Autofac.Core;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRSFeatures.Nozzles.Commands.Delete;
using CPTool.UIApp.AppPages.Nozzles;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class MWOItemNozzlesDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }

        protected MWOItemDialogData DialogData => DialogParent.DialogData;

        CommandMWOItem Model => DialogParent.Model;

        CommandNozzle SelectedNozzles = new();

        List<CommandNozzle> Elements => Model.Nozzles;

        public async Task<bool> ShowTableDialog(CommandNozzle nozzle)
        {

            if (nozzle.Id == 0)
            {
                nozzle= Model.AddNewNozzle( nozzle);

            }

            var result = await DialogService.OpenAsync<NozzleDialog>($"Add new Nozzle ",
                  new Dictionary<string, object> { { "Nozzle", nozzle }, { "SaveDialog", Model.Id != 0 } });
            if (result == null) return false;
            if ((bool)result == true)
            {
                if (Model.Id == 0) Model.Nozzles.Add(nozzle);

                await table.RefresheTable();
                await DialogParent.UpdateModel();

            }
            return (bool)result;

        }
        public async Task<bool> Delete(CommandNozzle model)
        {
            DeleteNozzleCommand delete = new() { Id = model.Id };
            var result = await Mediator.Send(delete);
            if (result.Success)
            {
                await table.RefresheTable();
                await DialogParent.UpdateModel();
            }
            return result.Success;
        }

    }
}
