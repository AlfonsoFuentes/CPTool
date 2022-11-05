

namespace CPTool.NewPages.Dialogs.UserRequirementType.List
{
    public partial class UserRequirementTypeList
    {
        
        async Task AddUserRequirementType()
        {
            EditUserRequirementType model = new();
            model.Key = GlobalTables.UserRequirementTypes.Count == 0 ? "URS 1" : $"URS {GlobalTables.UserRequirementTypes.Count + 1}"; 
            var result = await ToolDialogService.ShowNameDialog(model);
            if (!result.Cancelled)
            {
                GetUserRequirementTypeListQuery getUserRequirementList = new();
                GlobalTables.UserRequirementTypes = await Mediator.Send(getUserRequirementList);
            }
        }
    }
}
