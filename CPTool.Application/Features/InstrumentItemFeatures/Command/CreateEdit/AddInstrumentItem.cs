
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;


namespace CPTool.Application.Features.InstrumentItemFeatures.CreateEdit
{
    public class AddInstrumentItem : AddCommand
    {
      
        public AddProcessCondition? iProcessCondition { get; set; }
        public int? iProcessFluidId { get; set; }
        public int? iGasketId { get; set; }
        public int? iInnerMaterialId { get; set; }
        public int? iOuterMaterialId { get; set; }
        public int? MeasuredVariableId { get; set; }
        public int? MeasuredVariableModifierId { get; set; }
        public int? DeviceFunctionId { get; set; }
        public int? DeviceFunctionModifierId { get; set; }
        public int? ReadoutId { get; set; }

        public int? iBrandId { get; set; }
        public int? iSupplierId { get; set; }
        public string? TagId { get; set; }
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }

       
    }

}
