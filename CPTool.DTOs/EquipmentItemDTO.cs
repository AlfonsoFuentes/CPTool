
using CPtool.ExtensionMethods;
using CPTool.Entities;
using CPTool.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
namespace CPTool.DTOS
{


    public class EquipmentItemDTO :AuditableEntityDTO, IMapFrom<EquipmentItem>
    {
       



        public List<NozzleDTO>? NozzlesDTO { get; set; } = new();
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = null!;

        public EquipmentTypeDTO? EquipmentTypeDTO { get; set; } = null!;
        public EquipmentTypeSubDTO? EquipmentTypeSubDTO { get; set; } = null!;

        public ProcessConditionDTO? ProcessConditionDTO { get; set; } = null!;
        public ProcessFluidDTO? ProcessFluidDTO { get; set; } = null!;
        public BrandDTO? BrandDTO { get; set; } = null!;
        public SupplierDTO? SupplierDTO { get; set; } = null!;

        public GasketDTO? GasketDTO { get; set; } = null!;
        public MaterialDTO? InnerMaterialDTO { get; set; } = null!;
        public MaterialDTO? OuterMaterialDTO { get; set; } = null!;
        //public int? GasketId => GasketDTO?.Id == 0 ? null : GasketDTO?.Id;
        //public int? InnerMaterialId => InnerMaterialDTO?.Id == 0 ? null : InnerMaterialDTO?.Id;
        //public int? OuterMaterialId => OuterMaterialDTO?.Id == 0 ? null : OuterMaterialDTO?.Id;

        //public int? ProcessConditionId => ProcessConditionDTO?.Id == 0 ? null : ProcessConditionDTO?.Id;
        //public int? ProcessFluidId => ProcessFluidDTO?.Id == 0 ? null : ProcessFluidDTO?.Id;
        //public int? BrandId => BrandDTO?.Id == 0 ? null : BrandDTO?.Id;
        //public int? SupplierId => SupplierDTO?.Id == 0 ? null : SupplierDTO?.Id;

        //public int? EquipmentTypeId => EquipmentTypeDTO?.Id == 0 ? null : EquipmentTypeDTO?.Id;
        //public int? EquipmentTypeSubId => EquipmentTypeSubDTO?.Id == 0 ? null : EquipmentTypeSubDTO?.Id;
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
        public override void OnSubscribeTransferData()
        {
          
        }
        EquipmentItemDTO OnTransferdata(IAuditableEntityDTO dto)
        {
            if(dto is ProcessConditionDTO)
            {
                this.ProcessConditionDTO = dto as ProcessConditionDTO;
            }

            return this;
        }

    }






}
