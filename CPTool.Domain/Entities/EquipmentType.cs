namespace CPTool.Domain.Entities
{
    public class EquipmentType : AuditableEntity
    {
        public string? TagLetter { get; set; } = "";
        [ForeignKey("EquipmentTypeId")]
        public ICollection<EquipmentTypeSub>? EquipmentTypeSubs { get; set; }

        [ForeignKey("EquipmentTypeId")]
        public ICollection<Specification>? Specifications { get; set; }

        [ForeignKey("EquipmentTypeId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }

}
