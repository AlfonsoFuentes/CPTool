using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using CPTool.UIApp.AppPages.Nozzles;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Xml.Linq;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class MWOItemDialog
    {
        [Inject]
        public IMWOItemPrevisousValuesService PreviousValuesService { get; set; }
        public MWOItemPreviousValues PreviousValues { get; set; } = new();
       
        [Inject]
        public IMWOItemService Service { get; set; }
        [Parameter]
        public CommandMWOItem Model { get; set; } = new();
        public MWOItemDialogData DialogData = new MWOItemDialogData();
        protected override async Task OnInitializedAsync()
        {
           
            DialogData = await Service.GetMWOItemDataDialog();
            

        }
       
        
        
      
    }
}
