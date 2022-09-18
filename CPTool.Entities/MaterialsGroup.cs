namespace CPTool.Entities
{
    public class MaterialsGroup : AuditableEntity
    {
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
        public ICollection<InstrumentItem> InstrumentItems { get; set; } = null!;

        public Gasket? Gasket { get; set; }
        public Material? InnerMaterial { get; set; }
        public Material? OuterMaterial { get; set; }
        public int? GasketId { get; set; }
        public int? InnerMaterialId { get; set; }
        public int? OuterMaterialId { get; set; }
    }
}
