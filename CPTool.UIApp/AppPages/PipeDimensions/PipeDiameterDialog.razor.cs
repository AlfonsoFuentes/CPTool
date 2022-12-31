using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.PipeDimensions
{
    public partial class PipeDiameterDialog
    {
        [Inject]
        public IPipeDimensionService Service { get; set; }
        [Parameter]
        public CommandPipeDiameter Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdatePipeDiameter(Model);
        }
    }
}
