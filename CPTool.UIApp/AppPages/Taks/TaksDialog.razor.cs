using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Taks
{
    public partial class TaksDialog
    {
        [Inject]
        public ITaksService Service { get; set; }
        [Parameter]
        public CommandTaks Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
