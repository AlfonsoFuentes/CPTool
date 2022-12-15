
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;

using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

using CPToolRadzen.Pages.UserRequirement.Dialog;


namespace CPToolRadzen.Pages.UserRequirement.List
{
    public partial class UserRequirementList : TableTemplate<EditUserRequirement>
    {

        EditMWO Parent = new();

        EditUserRequirementType URType = new();

        protected override async Task OnInitializedAsync()
        {
            RadzenTables.UserRequirements = await CommandQuery.GetAll();
            Parent =await QueryMWO.GetById(ParentId);   
            TableName = "User Requirement";

           
        }
        public async Task<bool> ShowTableDialog(EditUserRequirement model)
        {
            if (model.Id == 0)
            {
                model.MWO = Parent;
                model.UserRequirementType = URType;

            }
            var result = await DialogService.OpenAsync<UserRequirementDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
        
    }
}
