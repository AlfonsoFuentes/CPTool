

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class EquipmentItemPage : CancellableComponent, IDisposable
    {
        [CascadingParameter]
        protected MWOItemDialog Dialog { get; set; }
        protected MWOItemDTO Item => Dialog.Model;

        [Parameter]
        public bool Visible { get; set; } = false;
        EquipmentItemDTO Model { get => Item.EquipmentItemDTO; set => Item.EquipmentItemDTO = value; }
        List<SupplierDTO> SupplierList = new();
        protected override void OnInitialized()
        {
            if (Model == null)
            {
                Model = new EquipmentItemDTO();
              
            }
            //SupplierList = Model.BrandDTO.Id == 0 ? new() : Model.BrandDTO.BrandSupplierDTOs.Select(x => x.SupplierDTO).ToList();

        }
        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                if (Model == null)
                {
                    Model = new EquipmentItemDTO();
                    Dialog.GetSaveEvent();
                }
                
            }
            base.OnAfterRender(firstRender);
        }

        public async Task<IResult<IAuditableEntityDTO>> OnSave(IAuditableEntityDTO dto)
        {
           
           
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

            SupplierList = Model.BrandDTO.Id == 0 ? new() : Model.BrandDTO.BrandSupplierDTOs.Select(x => x.SupplierDTO).ToList();
        }
        
        void IDisposable.Dispose()
        {
           

        }
        private string ValidateEquipmentType(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Equipment Type";
            if (!TablesService.ManEquipmentType.List.Any(x => x.Name == arg))
                return $"Equipment Type: {arg} is not in the list";
            return null;
        }
        async Task UpdateEquipmentType()
        {
            await TablesService.ManEquipmentType.UpdateList();
            Model.EquipmentTypeDTO = TablesService.ManEquipmentType.List.FirstOrDefault(x => x.Id == Model.EquipmentTypeDTO.Id);
            StateHasChanged();
            await Dialog.form.Validate();
        }
        private string ValidateEquipmentSubType(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!Model.EquipmentTypeDTO.EquipmentTypeSubDTOs.Any(x => x.Name == arg))
                return $"Equipment Sub Type: {arg} is not in the list";
            return null;
        }
        async Task UpdateEquipmentSubType()
        {
            await TablesService.ManEquipmentType.UpdateList();
            await TablesService.ManEquipmentTypeSub.UpdateList();
            Model.EquipmentTypeDTO = TablesService.ManEquipmentType.List.FirstOrDefault(x => x.Id == Model.EquipmentTypeDTO.Id);
            StateHasChanged();
            await Dialog.form.Validate();
        }
        private string ValidateGasket(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!TablesService.ManGasket.List.Any(x => x.Name == arg))
                return $"Gasket: {arg} is not in the list";
           
            return null;
        }
        async Task UpdateGasket()
        {
            await TablesService.ManGasket.UpdateList();
           
            StateHasChanged();
            await Dialog.form.Validate();
        }
        private string ValidateMaterial(string arg)
        {
            if (arg == null || arg == "")
                return null;
            if (!TablesService.ManMaterial.List.Any(x => x.Name == arg))
                return $"Material: {arg} is not in the list";

            return null;
        }
        async Task UpdateMaterial()
        {
            await TablesService.ManMaterial.UpdateList();

            StateHasChanged();
            await Dialog.form.Validate();
        }
    }
}
