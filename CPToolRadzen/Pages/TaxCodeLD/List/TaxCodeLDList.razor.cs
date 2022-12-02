
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;

using CPToolRadzen.Pages.TaxCodeLD.Dialog;


namespace CPToolRadzen.Pages.TaxCodeLD.List
{
    public partial class TaxCodeLDList : BaseTableTemplate<EditTaxCodeLD>
    {

        public override List<EditTaxCodeLD> Elements => RadzenTables.TaxCodeLDs;

        protected override void OnInitialized()
        {
            TableName = "Tax Code LD";
          
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditTaxCodeLD model)
        {

            var result = await DialogService.OpenAsync<TaxCodeLDDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
