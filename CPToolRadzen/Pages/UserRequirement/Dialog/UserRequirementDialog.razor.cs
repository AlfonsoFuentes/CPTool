
using CPTool.Application.Features.UserFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPToolRadzen.Pages.RequestedBy.Dialog;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace CPToolRadzen.Pages.UserRequirement.Dialog
{
    public partial class UserRequirementDialog : DialogTemplate<EditUserRequirement>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.UserRequirements : RadzenTables.UserRequirements.Where(x => x.Id != Model.Id).ToList();
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
