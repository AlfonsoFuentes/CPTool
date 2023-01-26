


using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.Domain.Entities;
using CPTool.InfrastructureCQRS.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class EquipmentDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected CommandMWOItem Model => DialogParent.Model;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;


       
       
    }
}
