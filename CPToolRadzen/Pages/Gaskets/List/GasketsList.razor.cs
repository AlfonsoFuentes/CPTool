using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

using CPToolRadzen.Pages.Gaskets.Dialog;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.Gaskets.List
{
    public partial class GasketsList : BaseTableTemplate<EditGasket>
    {

        public override List<EditGasket> Elements => RadzenTables.Gaskets;



        protected override void OnInitialized()
        {
            TableName = "Gasket";
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditGasket model)
        {

            var result = await DialogService.OpenAsync<GasketsDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
