using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPToolRadzen.Pages.Gaskets.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.Gaskets.List
{
    public partial class GasketsList : TableTemplate<EditGasket>
    {
        protected override async Task OnInitializedAsync()
        {
            RadzenTables.Gaskets = await CommandQuery.GetAll();
            TableName = "Gasket";
   
        }
        public async Task<bool> ShowTableDialog(EditGasket model)
        {

            var result = await DialogService.OpenAsync<GasketsDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
