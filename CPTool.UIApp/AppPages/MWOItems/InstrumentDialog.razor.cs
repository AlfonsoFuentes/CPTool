
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using CPTool.UIApp.AppPages.MWOItems;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class InstrumentDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected CommandInstrumentItem Model => DialogParent.Model.InstrumentItem;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;
        async Task ChangeBrand(int brandid)
        {
            Model.iSupplier = new();
            DialogData.Suppliers=await DialogParent.Service.GetSupliersByBrand(brandid);
        }
       
    }
}
