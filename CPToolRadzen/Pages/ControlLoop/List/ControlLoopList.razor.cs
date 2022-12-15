using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPToolRadzen.Pages.ControlLoop.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ControlLoop.List
{
    public partial class ControlLoopList : TableTemplate<EditControlLoop>
    {
        protected override async Task OnInitializedAsync()
        {
            RadzenTables.ControlLoops = await CommandQuery.GetAll();
            Parent = await QueryMWO.GetById(ParentId);
          

            TableName = "Control Loop";
            Filter = x => x.MWOId == ParentId;

        }
        EditMWO Parent = new();
        
        public async Task<bool> ShowTableDialog(EditControlLoop model)
        {
            if (model.Id == 0)
            {
                model.MWO = Parent;
            }
            var result = await DialogService.OpenAsync<ControlLoopDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } },
                  new DialogOptions() { Width = "1200px", Height = "750px", Resizable = true, Draggable = true });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
