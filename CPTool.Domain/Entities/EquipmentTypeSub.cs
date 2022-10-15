namespace CPTool.Domain.Entities
{
    public class EquipmentTypeSub  : BaseDomainModel
    {

        public int? EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; } = null!;


        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
        public string? TagLetter { get; set; }

    }
}
