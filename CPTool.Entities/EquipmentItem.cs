

namespace CPTool.Entities
{
    public class EquipmentItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;


        public virtual Gasket? Gasket { get; set; }
      
        public virtual Material? InnerMaterial { get; set; }
       
        public virtual Material? OuterMaterial { get; set; }
     
        public virtual EquipmentType? EquipmentType { get; set; }
       
        public virtual EquipmentTypeSub? EquipmentTypeSub { get; set; }
      
        public virtual Brand? Brand { get; set; }

      
        public virtual Supplier? Supplier { get; set; }

        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId { get; set; } = "";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

    }





}
