
using CPTool.Application.Features.UserFeatures.CreateEdit;

namespace CPToolRadzen.Pages.RequestedBy.Dialog
{
    public partial class RequestedByDialog : DialogTemplate<EditUser>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
