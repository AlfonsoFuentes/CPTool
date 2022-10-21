





using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.CreateEdit
{
    public class AddEquipmentItem : AddCommand
    {

       
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

      

        
    }

}
