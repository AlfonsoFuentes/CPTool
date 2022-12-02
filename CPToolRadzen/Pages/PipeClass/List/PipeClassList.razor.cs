using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;

using CPToolRadzen.Pages.PipeClass.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.PipeClass.List
{
    public partial class PipeClassList : BaseTableTemplate<EditPipeClass>
    {

       
        public override List<EditPipeClass> Elements => RadzenTables.PipeClasses;

        protected override void OnInitialized()
        {
            TableName = "Pipe Class";
       
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditPipeClass model)
        {

            var result = await DialogService.OpenAsync<PipeClassDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
