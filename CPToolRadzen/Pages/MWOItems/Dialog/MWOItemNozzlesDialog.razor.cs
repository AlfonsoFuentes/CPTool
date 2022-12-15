using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPToolRadzen.Pages.Nozzle.Dialog;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.MWOItems.Dialog
{
    public partial class MWOItemNozzlesDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditMWOItem Model => DialogParent.Model;
        List<EditNozzle> Nozzles => Model.Nozzles;
       
        string TableName => $"{Model.TagId} Nozzles";
   
        async Task<bool> AddNozzle(EditNozzle nozzle)
        {
            Model.AddNozzle(nozzle);
            var retorno = await ShowTableDialog(nozzle);
            if(!retorno)
            {
                Model.RemoveNozzle(nozzle); 
            }
            return retorno;
        }
        public async Task<bool> ShowTableDialog(EditNozzle model)
        {

            var result = await DialogService.OpenAsync<NozzleDialog>($"Add new Nozzle to {Model.TagId}",
                  new Dictionary<string, object> { { "Model", model }, { "SaveDialog", Model.Id==0?false:true } });
            if (result == null) return false;
           
            return (bool)result;

        }

    }
}
