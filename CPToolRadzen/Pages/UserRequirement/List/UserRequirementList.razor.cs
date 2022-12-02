
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.Query.GetList;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;
using CPTool.Services;
using CPToolRadzen.Pages.UserRequirement.Dialog;


namespace CPToolRadzen.Pages.UserRequirement.List
{
    public partial class UserRequirementList : BaseTableTemplate<EditUserRequirement>
    {

        EditMWO Parent => RadzenTables.MWOs.FirstOrDefault(x => x.Id == ParentId);

        EditUserRequirementType URType = new();
        public override List<EditUserRequirement> Elements => URType.Id == 0 ? new() :
             RadzenTables.UserRequirements.Where(x => x.UserRequirementTypeId == URType.Id&&x.MWOId==ParentId).ToList();
        protected override void OnInitialized()
        {
            TableName = "User Requirement";

            base.OnInitialized();
        }
        public async Task<bool> ShowDialog(EditUserRequirement model)
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
