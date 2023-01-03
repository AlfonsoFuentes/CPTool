using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.ControlLoops
{
    public partial class ControlLoopsDialog
    {
        [Inject]
        public IControlLoopService Service { get; set; }
        [Parameter]
        public CommandControlLoop Model { get; set; } = new();
        public ControlLoopDialogData DialogData = new();
        protected override async Task OnInitializedAsync()
        {
            DialogData = await Service.GetDialogData(Model);

           
        }
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
