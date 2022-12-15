
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

using CPToolRadzen.Pages.ProcessFluid.Dialog;


namespace CPToolRadzen.Pages.ProcessFluid.List
{
    public partial class ProcessFluidList : TableTemplate<EditProcessFluid>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.ProcessFluids = await CommandQuery.GetAll();
            TableName = "Process Fluid";
     
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditProcessFluid model)
        {

            var result = await DialogService.OpenAsync<ProcessFluidDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
