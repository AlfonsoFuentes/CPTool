using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.UserRequirementTypes
{
    public partial class UserRequirementTypesDialog
    {
        [Inject]
        public IUserRequirementTypeService Service { get; set; }
        [Parameter]
        public CommandUserRequirementType Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
