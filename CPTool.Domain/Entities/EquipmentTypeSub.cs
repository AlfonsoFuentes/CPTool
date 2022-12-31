namespace CPTool.Domain.Entities
{
    public class EquipmentTypeSub  : AuditableEntity
    {

        public int? EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; } = null!;

        [ForeignKey("eEquipmentTypeSubId")]
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
        public string? TagLetter { get; set; }

    }
}
