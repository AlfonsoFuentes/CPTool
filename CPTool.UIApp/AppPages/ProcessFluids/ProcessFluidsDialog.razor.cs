using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;

using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.ProcessFluids
{
    public partial class ProcessFluidsDialog
    {
        [Inject]
        public IProcessFluidsService Service { get; set; }
        [Parameter]
        public CommandProcessFluid Model { get; set; } = new();

        ProcessFluidsDialogData DataDialog = new();
        protected override async Task OnInitializedAsync()
        {
            DataDialog = await Service.GetDataDialog();
        }
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
            
        }
    }
}
