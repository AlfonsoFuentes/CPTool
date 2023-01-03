using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.MWOs
{
    public partial class MWODialog
    {
        [Inject]
        public IMWOService Service { get; set; }
        [Parameter]
        public CommandMWO Model { get; set; } = new();

        MWODialogData DialogData=new MWODialogData();
        protected override async Task OnInitializedAsync()
        {
            DialogData = await Service.GetMWODataDialog(Model);
        }
        async Task<BaseResponse> Save()
        {
            return await Service.AddUpdate(Model);
        }
    }
}
