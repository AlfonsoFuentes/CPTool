using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.FieldLocations
{
    public partial class FieldLocationDialog
    {
        [Inject]
        public IFieldLocationService Service { get; set; }
        [Parameter]
        public CommandFieldLocation Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
