using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.MWOTypes
{
    public partial class MWOTypeDialog
    {
        [Inject]
        public IMWOTypeService Service { get; set; }
        [Parameter]
        public CommandMWOType Model { get; set; } = new();
        async Task<BaseResponse> Save()
        {
           return await Service.AddUpdate(Model); 
        }
    }
}
