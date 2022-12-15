
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;

using CPToolRadzen.Pages.TaxCodeLP.Dialog;


namespace CPToolRadzen.Pages.TaxCodeLP.List
{
    public partial class TaxCodeLPList : TableTemplate<EditTaxCodeLP>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.TaxCodeLPs = await CommandQuery.GetAll();
            TableName = "Tax Code LP";
          
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditTaxCodeLP model)
        {

            var result = await DialogService.OpenAsync<TaxCodeLPDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
