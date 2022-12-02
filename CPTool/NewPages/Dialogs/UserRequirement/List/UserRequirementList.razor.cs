using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.Query.GetById;
using CPTool.Application.Features.UserRequirementFeatures.CreateEdit;
using CPTool.Application.Features.UserRequirementFeatures.Query.GetList;
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.UserRequirement.List
{
    public partial class UserRequirementList
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        
        [Parameter]
        public int MWOId { get; set; }
        EditMWO MWO => GlobalTables.MWOs.FirstOrDefault(x => x.Id == MWOId);
        EditUserRequirementType URType = new();
        List<EditUserRequirement> UserRequirements => URType.Id == 0 ? new() :
            GlobalTables.UserRequirements.Where(x => x.UserRequirementTypeId == URType.Id).ToList();

        EditUserRequirement EditUserRequirementSelected = new();
        protected override void   OnInitialized()
        {
           
            URType = GlobalTables.UserRequirementTypes.Count == 0 ? new() : GlobalTables.UserRequirementTypes.FirstOrDefault();

        }
        async Task AddUserRequirement()
        {
            EditUserRequirement model = new();
            model.MWO = MWO;
            model.UserRequirementType = URType;
            var result = await ToolDialogService.ShowUserRequirementDialog(model);
            if(!result.Cancelled)
            {
                GetUserRequirementListQuery getUserRequirementList = new();
                GlobalTables.UserRequirements = await Mediator.Send(getUserRequirementList);
            }
        }
        async Task EditUserRequirement()
        {
            var result = await ToolDialogService.ShowUserRequirementDialog(EditUserRequirementSelected);
            if (!result.Cancelled)
            {
                GetUserRequirementListQuery getUserRequirementList = new();
                GlobalTables.UserRequirements = await Mediator.Send(getUserRequirementList);
            }
        }


    }
}
