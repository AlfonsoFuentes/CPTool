
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;


namespace CPToolRadzen.Pages.UserRequirementType.Dialog
{
    public partial class UserRequirementTypeDialog : DialogTemplate<EditUserRequirementType>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.UserRequirementTypes : RadzenTables.UserRequirementTypes.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
