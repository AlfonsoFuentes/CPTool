namespace CPTool.Domain.Entities
{
    public class EquipmentTypeSub  : AuditableEntity
    {

        public int? EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; } = null!;

        [ForeignKey("EquipmentTypeSubId")]
        public ICollection<Specification>? Specifications { get; set; }
        public string? TagLetter { get; set; }

        [ForeignKey("EquipmentTypeSubId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }
}
