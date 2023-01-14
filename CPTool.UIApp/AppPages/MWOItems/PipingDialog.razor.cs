
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;

using CPTool.Domain.Enums;
using CPTool.UIApp.AppPages.MWOItems;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class PipingDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected CommandMWOItem Model => DialogParent.Model;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;


        async Task OnChangePipeClass(int pipeclasid)
        {
            Model.Diameter = new();
            DialogData.PipeDiameters = await DialogParent.Service.GetPipeDiameterByPipeClass(pipeclasid);
        }
        void OnChangeEquipmentStart()
        {
            DialogParent.DialogData = DialogParent.Service.OnChangeEquipmentStart(DialogData, Model);

            
            selectnozzlestart.Reset();
        }
        void OnChangeEquipmentFinish()
        {
            DialogParent.DialogData = DialogParent.Service.OnChangeEquipmentFinish(DialogData, Model);
            

            selectnozzlefinish.Reset();

        }
       
    }
}
