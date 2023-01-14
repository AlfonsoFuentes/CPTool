using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.EquipmentTypes
{
    public partial class EquipmentTypeSubDialog
    {
        [Inject]
        public IEquipmentTypeService Service { get; set; }
        [Parameter]
        public CommandEquipmentTypeSub Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdateEquipmentSub(Model);
        }
    }
}
