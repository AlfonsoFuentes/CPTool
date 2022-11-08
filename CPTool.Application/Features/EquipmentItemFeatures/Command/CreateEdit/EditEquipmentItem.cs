





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
        public List<EditNozzle>? Nozzles { get; set; }
        public int? eProcessConditionId => eProcessCondition?.Id == 0 ? null : eProcessCondition?.Id;
        public EditProcessCondition? eProcessCondition { get; set; } = new();
        public int? eProcessFluidId => eProcessFluid?.Id == 0 ? null : eProcessFluid?.Id;
        public EditProcessFluid? eProcessFluid { get; set; }

        public int? eGasketId => eGasket?.Id == 0 ? null : eGasket?.Id;
        public EditGasket? eGasket { get; set; }= new();
        public int? eInnerMaterialId => eInnerMaterial?.Id == 0 ? null : eInnerMaterial?.Id;
        public EditMaterial? eInnerMaterial { get; set; } = new();
        public int? eOuterMaterialId => eOuterMaterial?.Id == 0 ? null : eOuterMaterial?.Id;
        public EditMaterial? eOuterMaterial { get; set; } = new();
        public int? eEquipmentTypeId => eEquipmentType?.Id == 0 ? null : eEquipmentType?.Id;
        public EditEquipmentType? eEquipmentType { get; set; } = new();
        public int? eEquipmentTypeSubId => eEquipmentTypeSub?.Id == 0 ? null : eEquipmentTypeSub?.Id;
        public EditEquipmentTypeSub? eEquipmentTypeSub { get; set; } = new();
        public int? eBrandId => eBrand?.Id == 0 ? null : eBrand?.Id;
        public EditBrand? eBrand { get; set; } = new();
        public int? eSupplierId => eSupplier?.Id == 0 ? null : eSupplier?.Id;
        public EditSupplier? eSupplier { get; set; } = new();
        public string TagNumber { get; set; } = "";
        public string TagLetter => SetTagLetter();
        public string TagId => GetTagId();
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
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

        public override T AddDetailtoMaster<T>()
        {
            if (typeof(T) == typeof(EditNozzle))
            {
                EditNozzle detail = new();

                detail.Order = Nozzles!.Count == 0 ? 1 : this.Nozzles.OrderBy(x => x.Order).Last().Order + 1;
                detail.Name = $"N{detail.Order}";
                detail.EquipmentItem = this;
                if (Nozzles == null) Nozzles = new();
                Nozzles.Add(detail);
                

                return (detail as T)!;
            }
            return null!;
        }
    }

}
