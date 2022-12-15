
using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.FieldLocationsFeatures.CreateEdit;

using CPToolRadzen.Pages.FieldLocation.Dialog;


namespace CPToolRadzen.Pages.FieldLocation.List
{
    public partial class FieldLocationList : TableTemplate<EditFieldLocation>
    {
        protected override async Task OnInitializedAsync()
        {
            RadzenTables.FieldLocations = await QueryFieldLocation.GetAll();

           
            TableName = "Field Location";
          
        }
        public async Task<bool> ShowTableDialog(EditFieldLocation model)
        {

            var result = await DialogService.OpenAsync<FieldLocationDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
