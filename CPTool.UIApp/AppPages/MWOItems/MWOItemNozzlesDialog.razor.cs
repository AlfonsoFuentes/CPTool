

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
        protected CommandMWOItem Model => DialogParent.Model;

        CommandNozzle SelectedNozzles = new();
        string TableName => $"{Model.TagId} Nozzles";

        async Task<bool> AddNozzle(CommandNozzle nozzle)
        {
            Model.AddNozzle(nozzle);
            var retorno = await ShowTableDialog(nozzle);
            if (!retorno)
            {
                Model.RemoveNozzle(nozzle);
            }
            await table.RefresheTable();
            return retorno;
        }
        public async Task<bool> ShowTableDialog(CommandNozzle model)
        {

            var result = await DialogService.OpenAsync<NozzleDialog>($"Add new Nozzle to {Model.TagId}",
                  new Dictionary<string, object> { { "Model", model }, { "SaveDialog", Model.Id == 0 ? false : true } });
            if (result == null) return false;
            if ((bool)result == true)
            {
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
                await DialogParent.UpdateModel();
            }
            return result.Success;
        }

    }
}
