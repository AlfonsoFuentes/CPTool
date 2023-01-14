using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.PipeDimensions
{
    public partial class PipeClassDialog
    {
        [Inject]
        public IPipeDimensionService Service { get; set; }
        [Parameter]
        public CommandPipeClass Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdatePipeClass(Model);
        }
    }
}
