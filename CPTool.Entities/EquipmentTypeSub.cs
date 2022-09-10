namespace CPTool.Entities
{
    public class EquipmentTypeSub : AuditableEntity
    {

 
        public virtual EquipmentType EquipmentType { get; set; } = null!;


        public virtual ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
        public string? TagLetter { get; set; }

    }
}
