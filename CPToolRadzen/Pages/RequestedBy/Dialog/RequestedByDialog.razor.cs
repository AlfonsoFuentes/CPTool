
using CPTool.Application.Features.UserFeatures.CreateEdit;

namespace CPToolRadzen.Pages.RequestedBy.Dialog
{
    public partial class RequestedByDialog : DialogTemplate<EditUser>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.Users : RadzenTables.Users.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
