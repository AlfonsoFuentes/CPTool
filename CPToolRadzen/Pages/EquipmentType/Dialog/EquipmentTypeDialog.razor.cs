using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.EquipmentType.Dialog
{
    public partial class EquipmentTypeDialog : DialogTemplate<EditEquipmentType>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.EquipmentTypes : RadzenTables.EquipmentTypes.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
