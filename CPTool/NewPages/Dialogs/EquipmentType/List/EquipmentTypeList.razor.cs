
namespace CPTool.NewPages.Dialogs.EquipmentType.List
{
    public partial class EquipmentTypeList
    {
       
        EditEquipmentType SelectedEqu { get; set; } = new();
        EditEquipmentTypeSub SelectedEquSub { get; set; } = new();
        [Parameter]
        public RenderFragment OtherButtons { get; set; }

      
        
    }
}
