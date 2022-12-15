
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;

using CPToolRadzen.Pages.TaxCodeLD.Dialog;


namespace CPToolRadzen.Pages.TaxCodeLD.List
{
    public partial class TaxCodeLDList : TableTemplate<EditTaxCodeLD>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.TaxCodeLDs = await CommandQuery.GetAll();
            TableName = "Tax Code LD";
          
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditTaxCodeLD model)
        {

            var result = await DialogService.OpenAsync<TaxCodeLDDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
