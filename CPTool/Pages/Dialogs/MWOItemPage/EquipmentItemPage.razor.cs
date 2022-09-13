

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

            }
            SelectedSupplier = Model.BrandDTO.Id == 0 ? new() : Model.BrandDTO.BrandSupplierDTOs.Select(x => x.SupplierDTO).ToList();
          
           

        }
       

        public async Task<IResult<IAuditableEntityDTO>> OnSave(IAuditableEntityDTO dto)
        {
           
            if (Model.Id == 0)
                Model = _mapper.Map<CreateEquipmentItemDTO>(Model);
           var result=  await TablesService.ManItemEquipment.AddUpdate(Model, _cts.Token);
            if(result.Succeeded)
            {
                (dto as MWOItemDTO).EquipmentItemDTO = result.Data;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as MWOItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        void OnBrandValueChanged()
        {
            Model.SupplierDTO = new();

            SelectedSupplier = Model.BrandDTO.Id == 0 ? new() : Model.BrandDTO.BrandSupplierDTOs.Select(x => x.SupplierDTO).ToList();
        }
        
        void IDisposable.Dispose()
        {
           

        }
    }
}
