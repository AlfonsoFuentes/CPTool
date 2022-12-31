using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.Services;
using FluentValidation;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Nozzles
{
    public partial class NozzleDialog
    {
        [Inject]
        public INozzleService Service { get; set; }
        [Parameter]
        public CommandNozzle Model { get; set; } = new();

       

        [Parameter]
        public bool SaveDialog { get; set; }
        NozzleDialogData DialogData { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {

            DialogData = await Service.GetNozzleDataDialog(Model);
        }
        async Task<BaseResponse> Save()
        {
            if (SaveDialog)
                return await Service.AddUpdate(Model);
            return new();
        }
        async Task GetPipeDiameterByPipeClassId(int id)
        {
            Model.PipeDiameter = null;
            DialogData.PipeDiameters = await Service.GetPipeDiameterByPipeClass(id);
        }
    }
}
