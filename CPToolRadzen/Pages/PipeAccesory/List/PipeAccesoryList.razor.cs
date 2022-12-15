using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;

using CPToolRadzen.Pages.PipeAccesory.Dialog;
using CPToolRadzen.Templates;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.PipeAccesory.List
{
    public partial class PipeAccesoryList : TableTemplate<EditPipeAccesory>
    {

        [Parameter]
        public  List<EditPipeAccesory> ElmentsDetail { get; set; }
      

        protected override void OnInitialized()
        {
            TableName = "Pipe Accesorys";
            FilterFunc = () => ElmentsDetail;
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditPipeAccesory model)
        {

            var result = await DialogService.OpenAsync<PipeAccesoryDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
