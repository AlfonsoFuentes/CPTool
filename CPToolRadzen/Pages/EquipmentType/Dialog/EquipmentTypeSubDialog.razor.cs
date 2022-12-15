using CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit;

namespace CPToolRadzen.Pages.EquipmentType.Dialog
{
    public partial class EquipmentTypeSubDialog:DialogTemplate<EditEquipmentTypeSub>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);

            FilteredList = await CommandQuery.GetAll();
      
            FilteredList = Model.Id == 0 ? FilteredList.Where(x=>x.EquipmentTypeId==Model.EquipmentTypeId).ToList() : 
                FilteredList.Where(x => x.Id != Model.Id&& x.EquipmentTypeId == Model.EquipmentTypeId).ToList();
        }
    }
}
