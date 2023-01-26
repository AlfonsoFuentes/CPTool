

using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.UIApp.AppPages.MWOItems;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class InstrumentDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected CommandMWOItem Model => DialogParent.Model;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;
       
    }
}
