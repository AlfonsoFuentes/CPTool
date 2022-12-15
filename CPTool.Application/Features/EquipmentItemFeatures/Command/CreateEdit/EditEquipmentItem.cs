





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
    public class EditEquipmentItem : EditCommand, IRequest<Result<int>>
    {
        public List<EditNozzle>? Nozzles { get; set; } = new();
        public int? eProcessConditionId => eProcessCondition?.Id == 0 ? null : eProcessCondition?.Id;

        public EditProcessCondition? eProcessCondition { get; set; } = new();
        public int? eProcessFluidId => eProcessFluid?.Id == 0 ? null : eProcessFluid?.Id;
        public EditProcessFluid? eProcessFluid { get; set; }
        [Report(Order = 15)]
        public string ProcessFluidName => eProcessFluid==null?"": eProcessFluid!.Name;
        public int? eGasketId => eGasket?.Id == 0 ? null : eGasket?.Id;
        public EditGasket? eGasket { get; set; }= new();
        [Report(Order = 16)]
        public string GasketName => eGasket == null ? "" : eGasket!.Name;
        public int? eInnerMaterialId => eInnerMaterial?.Id == 0 ? null : eInnerMaterial?.Id;
        public EditMaterial? eInnerMaterial { get; set; } = new();
        [Report(Order = 17)]
        public string InnerMaterialName => eInnerMaterial == null ? "" : eInnerMaterial!.Name;
        public int? eOuterMaterialId => eOuterMaterial?.Id == 0 ? null : eOuterMaterial?.Id;

        public EditMaterial? eOuterMaterial { get; set; } = new();
        [Report(Order = 18)]
        public string OuterMaterialName => eOuterMaterial == null ? "" : eOuterMaterial!.Name;
        public int? eEquipmentTypeId => eEquipmentType?.Id == 0 ? null : eEquipmentType?.Id;
        public EditEquipmentType? eEquipmentType { get; set; } = new();
        [Report(Order = 19)]
        public string EquipmentTypeName => eEquipmentType == null ? "" : eEquipmentType!.Name;
        public int? eEquipmentTypeSubId => eEquipmentTypeSub?.Id == 0 ? null : eEquipmentTypeSub?.Id;
        [Report(Order = 20)]
        public string EquipmentTypeSubName => eEquipmentTypeSub == null ? "" : eEquipmentTypeSub!.Name;
        public EditEquipmentTypeSub? eEquipmentTypeSub { get; set; } = new();
        public int? eBrandId => eBrand?.Id == 0 ? null : eBrand?.Id;

        public EditBrand? eBrand { get; set; } = new();
        [Report(Order = 21)]
        public string BrandName => eBrand == null ? "" : eBrand!.Name;
        public int? eSupplierId => eSupplier?.Id == 0 ? null : eSupplier?.Id;
        public EditSupplier? eSupplier { get; set; } = new();
        [Report(Order = 22)]
        public string SupplierName => eSupplier == null ? "" : eSupplier!.Name;
      
        public string TagNumber { get; set; } = "";
       
        public string TagLetter => SetTagLetter();
       
        public string TagId => GetTagId();
        [Report(Order =23)]
        public string Model { get; set; } = "";
        [Report(Order = 24)]
        public string Reference { get; set; } = "";
        [Report(Order = 25)]
        public string SerialNumber { get; set; } = "";

        public string GetTagId()
        {
            if (TagLetter == "") return "";
            if (TagNumber == "") return $"{TagLetter}";
            return $"{TagLetter}_{TagNumber}";

          
        }
        string SetTagLetter()
        {
            if (eEquipmentType == null) return "";

            string tag = $"{eEquipmentType?.TagLetter}{eEquipmentTypeSub?.TagLetter}";
            return tag;
        }

        
    }

}
