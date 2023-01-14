using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Signals
{
    public partial class SignalsDialog
    {
        [Inject]
        public ISignalService Service { get; set; }
        [Parameter]
        public CommandSignal Model { get; set; } = new();
        SignalDialogData DialogData = new();
        protected override async Task OnInitializedAsync()
        {
            DialogData = await Service.GetDialogData();
        }
        async Task<BaseResponse> Save()
        {
            if(Model.MWOItem.Id!=0)
            {
                return await Service.AddUpdate(Model);
            }
          return new() { Success=true };
        }
    }
}
