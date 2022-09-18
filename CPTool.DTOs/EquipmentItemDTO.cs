
using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{

    public class EquipmentItemDTO : AuditableEntityDTO
    {


        public List<MWOItemDTO> MWOItemDTOs { get; set; } = new();

        public EquipmentTypeDTO? EquipmentTypeDTO { get; set; } = new();
        public EquipmentTypeSubDTO? EquipmentTypeSubDTO { get; set; } = new();
        public BrandDTO? BrandDTO { get; set; } = new();
        public SupplierDTO? SupplierDTO { get; set; } = new();

        public MaterialsGroupDTO? MaterialsGroupDTO { get; set; } = new();
        public int? MaterialsGroupId => MaterialsGroupDTO?.Id;


        public int? EquipmentTypeId => EquipmentTypeDTO?.Id == 0 ? null : EquipmentTypeDTO?.Id;
        public int? EquipmentTypeSubId => EquipmentTypeSubDTO?.Id == 0 ? null : EquipmentTypeSubDTO?.Id;
        public int? BrandId => BrandDTO?.Id == 0 ? null : BrandDTO?.Id;
        public int? SupplierId => SupplierDTO?.Id == 0 ? null : SupplierDTO?.Id;


        public string TagNumber { get; set; } = "";
        public string TagLetter => SetTagLetter();
        public string TagId => SetTagId();
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
