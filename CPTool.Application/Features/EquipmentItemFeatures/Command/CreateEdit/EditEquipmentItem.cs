





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
        //public int? ProcessConditionId => ProcessCondition?.Id == 0 ? null : ProcessCondition?.Id;
        public EditProcessCondition? ProcessCondition { get; set; } = new();
        //public int? ProcessFluidId => ProcessFluid?.Id == 0 ? null : ProcessCondition?.Id;
        public EditProcessFluid? ProcessFluid { get; set; } = new();

        //public int? GasketId => Gasket?.Id == 0 ? null : Gasket?.Id;
        public EditGasket? Gasket { get; set; } = new();
        //public int? eInnerMaterialId => eInnerMaterial?.Id == 0 ? null : eInnerMaterial?.Id;
        public EditMaterial? eInnerMaterial { get; set; } = new();
        //public int? eOuterMaterialId => eOuterMaterial?.Id == 0 ? null : eOuterMaterial?.Id;
        public EditMaterial? eOuterMaterial { get; set; } = new();
        //public int? EquipmentTypeId => EquipmentType?.Id == 0 ? null : EquipmentType?.Id;
        public EditEquipmentType? EquipmentType { get; set; } = new();
        //public int? EquipmentTypeSubId => EquipmentTypeSub?.Id == 0 ? null : EquipmentTypeSub?.Id;
        public EditEquipmentTypeSub? EquipmentTypeSub { get; set; } = new();
        //public int? BrandId => Brand?.Id == 0 ? null : Brand?.Id;
        public EditBrand? Brand { get; set; } = new();
        //public int? SupplierId => Supplier?.Id == 0 ? null : Supplier?.Id;
        public EditSupplier? Supplier { get; set; } = new();
        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId => $"{EquipmentType?.TagLetter}{EquipmentTypeSub?.TagLetter}-{TagNumber}";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

 

        //public override T AddDetailtoMaster<T>()
        //{
        //    if (typeof(T) == typeof(EditNozzle))
        //    {
        //        EditNozzle detail = new();

        //        detail.Order = this.Nozzles.Count == 0 ? 1 : this.Nozzles.OrderBy(x => x.Order).Last().Order + 1;
        //        detail.Name = $"N{detail.Order}";
        //        detail.ParentNozzles = this.Nozzles;
        //        detail.EquipmentItem = this;
        //        return (detail as T)!;
        //    }
        //    return null!;
        //}
    }

}
