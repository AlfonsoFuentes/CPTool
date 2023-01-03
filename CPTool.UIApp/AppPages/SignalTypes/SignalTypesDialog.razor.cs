using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.SignalTypes
{
    public partial class SignalTypesDialog
    {
        [Inject]
        public ISignalTypeService Service { get; set; }
        [Parameter]
        public CommandSignalType Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
