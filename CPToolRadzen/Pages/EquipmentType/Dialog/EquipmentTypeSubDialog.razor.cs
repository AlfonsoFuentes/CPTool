using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;

namespace CPToolRadzen.Pages.EquipmentType.Dialog
{
    public partial class EquipmentTypeSubDialog:DialogTemplate<EditEquipmentTypeSub>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.EquipmentTypeSubs : RadzenTables.EquipmentTypeSubs.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
