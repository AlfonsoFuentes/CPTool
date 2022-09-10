
using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public partial class EquipmentItemDTO : AuditableEntityDTO
    {


        public List<MWOItemDTO> MWOItemDTOs { get; set; }
        public virtual GasketDTO? GasketDTO { get; set; } = new();

        public virtual MaterialDTO? InnerMaterialDTO { get; set; } = new();

        public virtual MaterialDTO? OuterMaterialDTO { get; set; } = new();

        public virtual EquipmentTypeDTO? EquipmentTypeDTO { get; set; } = new();

        public virtual EquipmentTypeSubDTO? EquipmentTypeSubDTO { get; set; } = new();

        public virtual BrandDTO? BrandDTO { get; set; } = new();


        public virtual SupplierDTO? SupplierDTO { get; set; } = new();

        public string TagNumber { get; set; } = "";
        public string TagLetter => SetTagLetter();
        public  string TagId => SetTagId();
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";
        string SetTagLetter()
        {
            string tag = $"{EquipmentTypeDTO?.TagLetter}{EquipmentTypeSubDTO?.TagLetter}";

            return tag;
        }
        string SetTagId()
        {
            var tag = $"{TagLetter}_{TagNumber}";

            return tag;
        }

    }





}
