
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

using CPToolRadzen.Pages.UserRequirementType.Dialog;


namespace CPToolRadzen.Pages.UserRequirementType.List
{
    public partial class UserRequirementTypeList : BaseTableTemplate<EditUserRequirementType>
    {

        public override List<EditUserRequirementType> Elements => RadzenTables.UserRequirementTypes;


        protected override void OnInitialized()
        {
            TableName = "User Requirement type";
          
            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditUserRequirementType model)
        {

            var result = await DialogService.OpenAsync<UserRequirementTypeDialog>(model.Id == 0 ? $"Add new {TableName}" : $"Edit {model.Name}",
                  new Dictionary<string, object> { { "Model", model } });
            if (result == null) return false;
            return (bool)result;

        }
    }
}
