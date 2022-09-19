

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class PipingtItemPage : CancellableComponent, IDisposable
    {
        [CascadingParameter]
        protected MWOItemDialog Dialog { get; set; }
        protected MWOItemDTO Item => Dialog.Model;

       
        PipingItemDTO Model { get => Item.PipingItemDTO; set => Item.PipingItemDTO = value; }
      
        protected override void OnInitialized()
        {
            if (Model == null)
            {
                Model = new ();
              
            }
           
        }



        

        //private string ValidateEquipmentType(string arg)
        //{
        //    if (arg == null || arg == "")
        //        return "Must submit Equipment Type";
        //    if (!TablesService.ManEquipmentType.List.Any(x => x.Name == arg))
        //        return $"Equipment Type: {arg} is not in the list";
        //    return null;
        //}
        //async Task UpdateEquipmentType()
        //{
        //    await TablesService.ManEquipmentType.UpdateList();
        //    Model.EquipmentTypeDTO = TablesService.ManEquipmentType.List.FirstOrDefault(x => x.Id == Model.EquipmentTypeDTO.Id);
        //    StateHasChanged();

        //}
        //private string ValidateEquipmentSubType(string arg)
        //{
        //    if (arg == null || arg == "")
        //        return null;
        //    if (!Model.EquipmentTypeDTO.EquipmentTypeSubDTOs.Any(x => x.Name == arg))
        //        return $"Equipment Sub Type: {arg} is not in the list";
        //    return null;
        //}
        //async Task UpdateEquipmentSubType()
        //{
        //    await TablesService.ManEquipmentType.UpdateList();
        //    await TablesService.ManEquipmentTypeSub.UpdateList();
        //    Model.EquipmentTypeDTO = TablesService.ManEquipmentType.List.FirstOrDefault(x => x.Id == Model.EquipmentTypeDTO.Id);
        //    StateHasChanged();

        //}
       
    }
}
