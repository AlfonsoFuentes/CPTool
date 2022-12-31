using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate
{
    public class AddEquipmentItem
    {

       
        public string Name { get; set; } = string.Empty;
        public AddProcessCondition? eProcessCondition { get; set; }
        public int? eProcessFluidId { get; set; }


        public int? eGasketId { get; set; }

        public int? eInnerMaterialId { get; set; }

        public int? eOuterMaterialId { get; set; }

        public int? eEquipmentTypeId { get; set; }

        public int? eEquipmentTypeSubId { get; set; }

        public int? eBrandId { get; set; }

        public int? eSupplierId { get; set; }

        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string? TagId { get; set; }
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";


        public List<AddNozzle>? Nozzles { get; set; }
    }
    public class UpdateEquipmentItem
    {


        public string Name { get; set; } = string.Empty;
       
        public int? eProcessFluidId { get; set; }


        public int? eGasketId { get; set; }

        public int? eInnerMaterialId { get; set; }

        public int? eOuterMaterialId { get; set; }

        public int? eEquipmentTypeId { get; set; }

        public int? eEquipmentTypeSubId { get; set; }

        public int? eBrandId { get; set; }

        public int? eSupplierId { get; set; }

        public string TagNumber { get; set; } = "";
        public string TagLetter { get; set; } = "";
        public string? TagId { get; set; }
        public string Model { get; set; } = "";
        public string Reference { get; set; } = "";
        public string SerialNumber { get; set; } = "";


        public List<AddNozzle>? Nozzles { get; set; }
    }

}
