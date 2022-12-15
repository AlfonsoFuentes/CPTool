using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

using CPToolRadzen.Pages.PipeDiameter.Dialog;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.PipeDiameter.List
{
    public partial class PipeDiameterList : TableTemplate<EditPipeDiameter>
    {
      


        protected override void OnInitialized()
        {
         
            TableName = "Pipe Diameter";

            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditPipeDiameter model)
        {
            if (model.Id == 0)
            {
                model.dPipeClass = await QueryPipeClass.GetById(ParentId);
            }
            var result = await DialogService.OpenAsync<PipeDiameterDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
