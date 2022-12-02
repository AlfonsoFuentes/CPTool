
using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;

using CPToolRadzen.Pages.FieldLocation.Dialog;


namespace CPToolRadzen.Pages.FieldLocation.List
{
    public partial class FieldLocationList : BaseTableTemplate<EditFieldLocation>
    {
        public override List<EditFieldLocation> Elements => RadzenTables.FieldLocations;


        protected override void OnInitialized()
        {
            TableName = "Field Location";
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditFieldLocation model)
        {

            var result = await DialogService.OpenAsync<FieldLocationDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
