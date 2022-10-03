
namespace CPTool.NewPages.Dialogs.EquipmentType.List
{
    public partial class EquipmentTypeList
    {
       
        AddEditEquipmentTypeCommand SelectedEqu { get; set; } = new();
        AddEditEquipmentTypeSubCommand SelectedEquSub { get; set; } = new();
        [Parameter]
        public RenderFragment OtherButtons { get; set; }

      
        
    }
}
