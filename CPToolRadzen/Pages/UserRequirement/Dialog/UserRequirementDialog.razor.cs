
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPToolRadzen.Pages.RequestedBy.Dialog;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace CPToolRadzen.Pages.UserRequirement.Dialog
{
    public partial class UserRequirementDialog : DialogTemplate<EditUserRequirement>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
            RadzenTables.Users = await QueryUser.GetAll();
        }
        async Task<bool> ShowUSerDialog(EditUser model)
        {
            var result = await DialogService.OpenAsync<RequestedByDialog>(model.Id == 0 ? $"Add new User" : $"Edit {model.Name}",
      new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;
        }
    }
}
