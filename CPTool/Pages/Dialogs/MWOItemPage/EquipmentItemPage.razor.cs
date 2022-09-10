

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class EquipmentItemPage : CancellableComponent, IDisposable
    {
        [CascadingParameter]
        public MWOItemDTO Item { get; set; }

        EquipmentItemDTO Model { get => Item.EquipmentItemDTO; set => Item.EquipmentItemDTO = value; }
        List<SupplierDTO> SelectedSupplier = new();
        protected override void OnInitialized()
        {
            if (Model == null)
            {
                Model = new EquipmentItemDTO();
                //Model.MWOItemId = Item.Id;
            }
            OnBrandValueChanged();
            TablesService.Save += OnSave;
            TablesService.UpdateForm += UpdateForm;

        }
        void UpdateForm()
        {
            if (Model.EquipmentTypeDTO.Id == 0)
            {
               
                Model.EquipmentTypeSubDTO = new();
            }



            StateHasChanged();
        }

        public async Task<IResult<IAuditableEntityDTO>> OnSave(IAuditableEntityDTO dto)
        {
            if (Model.Id != 0) return await TablesService.ManItemEquipment.AddUpdate(Model, _cts.Token);

            return Result<IAuditableEntityDTO>.Success();
        }
        void OnBrandValueChanged()
        {
            Model.SupplierDTO = new();
           
            SelectedSupplier = Model.BrandDTO.Id == 0 ? new() : Model.BrandDTO.BrandSupplierDTOs.Select(x => x.SupplierDTO).ToList();
        }
        void OnSupplierValueChanged(int value)
        {

            Model.SupplierDTO = TablesService.ManSupplier.List.FirstOrDefault(x => x.Id == value);
            
        }
        void IDisposable.Dispose()
        {
            TablesService.Save -= OnSave;
            TablesService.UpdateForm -= UpdateForm;
        }
    }
}
