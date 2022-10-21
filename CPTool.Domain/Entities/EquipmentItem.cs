namespace CPTool.Domain.Entities
{
    public class EquipmentItem  : BaseDomainModel
    {
        [ForeignKey("EquipmentItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

        [ForeignKey("EquipmentItemId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public int? eProcessConditionId { get; set; }
        public ProcessCondition? eProcessCondition { get; set; } = null!;
        public int? eProcessFluidId { get; set; }
        public ProcessFluid? eProcessFluid { get; set; } = null!;
        

        public int? eGasketId { get; set; }
        public Gasket? eGasket { get; set; } = null!;
        public int? eInnerMaterialId { get; set; }
        public Material? eInnerMaterial { get; set; } = null!;
        public int? eOuterMaterialId { get; set; }
        public Material? eOuterMaterial { get; set; } = null!;
        public int? eEquipmentTypeId { get; set; }
        public EquipmentType? eEquipmentType { get; set; } = null!;
        public int? eEquipmentTypeSubId { get; set; }
        public EquipmentTypeSub? eEquipmentTypeSub { get; set; } = null!;
        public int? eBrandId { get; set; }
        public Brand? eBrand { get; set; } = null!;
        public int? eSupplierId { get; set; }
        public Supplier? eSupplier { get; set; } = null!;
        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId { get; set; } = "";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

    }





}
