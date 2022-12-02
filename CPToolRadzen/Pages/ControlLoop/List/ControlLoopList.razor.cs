using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPToolRadzen.Pages.ControlLoop.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ControlLoop.List
{
    public partial class ControlLoopList : BaseTableTemplate<EditControlLoop>
    {

        EditMWO Parent => RadzenTables.MWOs.FirstOrDefault(x => x.Id == ParentId);
        public override List<EditControlLoop> Elements => RadzenTables.ControlLoops.Where(x => x.MWOId == ParentId).ToList();
        protected override void OnInitialized()
        {
            TableName = "Control Loop";
      
          
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditControlLoop model)
        {

            var result = await DialogService.OpenAsync<ControlLoopDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
