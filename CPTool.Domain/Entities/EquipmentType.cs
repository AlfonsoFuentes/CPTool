namespace CPTool.Domain.Entities
{
    public class EquipmentType : BaseDomainModel
    {
        public string? TagLetter { get; set; } = "";
        public ICollection<EquipmentTypeSub>? EquipmentTypeSubs { get; set; }
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;

    }

}
