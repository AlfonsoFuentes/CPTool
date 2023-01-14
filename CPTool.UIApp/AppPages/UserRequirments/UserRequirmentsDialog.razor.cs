using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.UserRequirments
{
    public partial class UserRequirmentsDialog
    {
        [Inject]
        public IUserRequirementService Service { get; set; }
        [Parameter]
        public CommandUserRequirement Model { get; set; } = new();

        UserRequirementDialogData DialogData = new();
        protected override async Task OnInitializedAsync()
        {
            DialogData = await Service.GetDialogData();
        }
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);

        }
    }
}
