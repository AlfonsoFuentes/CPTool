

using CPToolRadzen.Pages.ConnectionTypes.Dialog;

namespace CPToolRadzen.Pages.ConnectionTypes.List
{
    public partial class ConnectionTypesList : TableTemplate<EditConnectionType>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.ConnectionTypes = await CommandQuery.GetAll();
          

             TableName = "Connection Type";
           
           
        }
        public async Task<bool> ShowTableDialog(EditConnectionType model)
        {

            var result = await DialogService.OpenAsync<ConnectionTypesDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
