

namespace CPTool.Entities
{
    public class EquipmentItem : AuditableEntity
    {
        public  ICollection<MWOItem> MWOItems { get; set; } = null!;


        public  Gasket? Gasket { get; set; }
        public  Material? InnerMaterial { get; set; }
        public  Material? OuterMaterial { get; set; }
        public  EquipmentType? EquipmentType { get; set; }
        public  EquipmentTypeSub? EquipmentTypeSub { get; set; }
        public  Brand? Brand { get; set; }
        public  Supplier? Supplier { get; set; }

        public int? GasketId { get; set; }
        public int? InnerMaterialId { get; set; }
        public int? OuterMaterialId { get; set; }
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
