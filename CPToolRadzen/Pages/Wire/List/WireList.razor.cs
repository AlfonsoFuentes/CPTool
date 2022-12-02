
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;
using CPTool.Application.Features.WireFeatures.CreateEdit;

using CPToolRadzen.Pages.Wire.Dialog;


namespace CPToolRadzen.Pages.Wire.List
{
    public partial class WireList : BaseTableTemplate<EditWire>
    {

        public override List<EditWire> Elements => RadzenTables.Wires;


        protected override void OnInitialized()
        {
            TableName = "Wire";
          
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditWire model)
        {

            var result = await DialogService.OpenAsync<WireDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
