using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Wires
{
    public partial class WiresDialog
    {
        [Inject]
        public IWireService Service { get; set; }
        [Parameter]
        public CommandWire Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
