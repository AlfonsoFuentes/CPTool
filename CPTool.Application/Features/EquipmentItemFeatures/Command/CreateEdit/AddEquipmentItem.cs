





using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.CreateEdit
{
    public class AddEquipmentItem : AddCommand, IRequest<Result<int>>
    {
      
      
        public AddProcessCondition ProcessCondition { get; set; } = new();
        public int? ProcessFluidId => ProcessFluidCommand?.Id==0 ? null : ProcessFluidCommand?.Id;
        public EditProcessFluid? ProcessFluidCommand { get; set; } = new();

        public int? GasketId => GasketCommand?.Id==0 ? null : GasketCommand?.Id;
        public EditGasket? GasketCommand { get; set; } = new();
        public int? eInnerMaterialId => eInnerMaterialCommand?.Id==0 ? null : eInnerMaterialCommand?.Id;
        public EditMaterial? eInnerMaterialCommand { get; set; } = new();
        public int? eOuterMaterialId => eOuterMaterialCommand?.Id==0 ? null : eOuterMaterialCommand?.Id;
        public EditMaterial? eOuterMaterialCommand { get; set; } = new();
        public int? EquipmentTypeId => EquipmentTypeCommand?.Id==0 ? null : EquipmentTypeCommand?.Id;
        public EditEquipmentType? EquipmentTypeCommand { get; set; } = new();
        public int? EquipmentTypeSubId => EquipmentTypeSubCommand?.Id==0 ? null : EquipmentTypeSubCommand?.Id;
        public EditEquipmentTypeSub? EquipmentTypeSubCommand { get; set; } = new();
        public int? BrandId => BrandCommand?.Id==0? null : BrandCommand?.Id;
        public EditBrand? BrandCommand { get; set; } = new();
        public int? SupplierId => SupplierCommand?.Id==0 ? null : SupplierCommand?.Id;
        public EditSupplier? SupplierCommand { get; set; } = new();
        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId  => $"{EquipmentTypeCommand?.TagLetter}{EquipmentTypeSubCommand?.TagLetter}-{TagNumber}";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

      

        
    }

}
