

namespace CPTool.Entities
{
    public class EquipmentItem : AuditableEntity
    {
        public  ICollection<MWOItem> MWOItems { get; set; } = null!;

        public MaterialsGroup? MaterialsGroup { get; set; }
       
        public  EquipmentType? EquipmentType { get; set; }
        public  EquipmentTypeSub? EquipmentTypeSub { get; set; }
        public  Brand? Brand { get; set; }
        public  Supplier? Supplier { get; set; }

        public ProcessCondition? ProcessCondition { get; set; }
        public ProcessFluid? ProcessFluid { get; set; }
        public int? ProcessConditionId { get; set; }
        public int? ProcessFluidId { get; set; }
        public int? MaterialsGroupId { get; set; }
        
        public int? EquipmentTypeId { get; set; }
        public int? EquipmentTypeSubId { get; set; }
        public int? BrandId { get; set; }
        public int? SupplierId { get; set; }
       

        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string TagId { get; set; } = "";
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";

    }





}
