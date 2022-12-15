
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.UserFeatures.CreateEdit;

using CPToolRadzen.Pages.RequestedBy.Dialog;


namespace CPToolRadzen.Pages.RequestedBy.List
{
    public partial class RequestedByList : TableTemplate<EditUser>
    {

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.Users = await CommandQuery.GetAll();
            TableName = "User";
  
            base.OnInitialized();
        }
        public async Task<bool> ShowTableDialog(EditUser model)
        {

            var result = await DialogService.OpenAsync<RequestedByDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
