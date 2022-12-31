

using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;
using CPTool.UIApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.UIApp.AppPages.MWOItems
{
    public partial class EquipmentDialog
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected CommandEquipmentItem Model => DialogParent.Model.EquipmentItem;
        protected MWOItemDialogData DialogData => DialogParent.DialogData;


        async Task ChangeBrand( int brandid)
        {
            Model.eSupplier = new();

            DialogData.Suppliers=await DialogParent.Service.GetSupliersByBrand(brandid);    
        }
        async Task ChangeEquipmentType(int equipmenttypeid)
        {
            Model.eEquipmentTypeSub = new();

            DialogData.EquipmentTypeSubs=await DialogParent.Service.GetEquipmentTypeSubByEquipmentType(equipmenttypeid);
        }
    }
}
