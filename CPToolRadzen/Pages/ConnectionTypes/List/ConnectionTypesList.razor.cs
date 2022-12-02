

using CPToolRadzen.Pages.ConnectionTypes.Dialog;

namespace CPToolRadzen.Pages.ConnectionTypes.List
{
    public partial class ConnectionTypesList : BaseTableTemplate<EditConnectionType>
    {

       public override List<EditConnectionType> Elements => RadzenTables.ConnectionTypes;
        protected override void OnInitialized()
        {
            TableName = "Connection Type";
           
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditConnectionType model)
        {

            var result = await DialogService.OpenAsync<ConnectionTypesDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
