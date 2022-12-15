
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;

using CPToolRadzen.Pages.Nozzle.Dialog;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.Nozzle.List
{
    public partial class NozzleList : TableTemplate<EditNozzle>
    {
        [Parameter]
        public bool SaveDialog { get; set; }
        [Parameter]
        public List<EditNozzle> ElementDetails { get; set; }

       
        protected override void OnInitialized()
        {
            TableName = "Nozzle";
        
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditNozzle model)
        {

            var result = await DialogService.OpenAsync<NozzleDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model }, { "SaveDialog", SaveDialog } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
