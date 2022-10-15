namespace CPTool.Domain.Entities
{
    public class EquipmentItem  : BaseDomainModel
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public int? ProcessConditionId { get; set; }
        public ProcessCondition? ProcessCondition { get; set; } = null!;
        public int? ProcessFluidEquipmentId { get; set; }
        public ProcessFluid? ProcessFluidEquipment { get; set; } = null!;
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
        public int? GasketId { get; set; }
        public Gasket? Gasket { get; set; } = null!;
        public int? eInnerMaterialId { get; set; }
        public Material? eInnerMaterial { get; set; } = null!;
        public int? eOuterMaterialId { get; set; }
        public Material? eOuterMaterial { get; set; } = null!;
        public int? EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; } = null!;
        public int? EquipmentTypeSubId { get; set; }
        public EquipmentTypeSub? EquipmentTypeSub { get; set; } = null!;
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; } = null!;
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; } = null!;
        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId { get; set; } = "";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

    }





}
