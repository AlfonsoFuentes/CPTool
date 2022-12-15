
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;

using CPToolRadzen.Pages.UnitaryBasePrize.Dialog;


namespace CPToolRadzen.Pages.UnitaryBasePrize.List
{
    public partial class UnitaryBasePrizeList : TableTemplate<EditUnitaryBasePrize>
    {


        protected override async Task OnInitializedAsync()
        {
            RadzenTables.UnitaryBasePrizes = await CommandQuery.GetAll();
            TableName = "Unitary prize name";
          
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditUnitaryBasePrize model)
        {

            var result = await DialogService.OpenAsync<UnitaryBasePrizeDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
