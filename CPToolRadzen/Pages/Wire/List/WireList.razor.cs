
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;
using CPTool.Application.Features.WireFeatures.CreateEdit;

using CPToolRadzen.Pages.Wire.Dialog;


namespace CPToolRadzen.Pages.Wire.List
{
    public partial class WireList : TableTemplate<EditWire>
    {


        protected override async Task OnInitializedAsync()
        {
            RadzenTables.Wires = await CommandQuery.GetAll();
            TableName = "Wire";
          
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditWire model)
        {

            var result = await DialogService.OpenAsync<WireDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
