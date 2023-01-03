using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.ElectricalBoxes
{
    public partial class ElectricalBoxesDialog
    {
        [Inject]
        public IElectricalBoxService Service { get; set; }
        [Parameter]
        public CommandElectricalBox Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
