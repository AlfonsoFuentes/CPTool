namespace CPTool.Domain.Entities
{
    public class EquipmentType : BaseDomainModel
    {
        public string? TagLetter { get; set; } = "";
        [ForeignKey("EquipmentTypeId")]
        public ICollection<EquipmentTypeSub>? EquipmentTypeSubs { get; set; }

        [ForeignKey("eEquipmentTypeId")]
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;

    }

}
