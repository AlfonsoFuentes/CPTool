





using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;
using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.ReadoutFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.Application.Features.InstrumentItemFeatures.CreateEdit
{
    public class EditInstrumentItem : EditCommand
    {
        public List<EditNozzle>? Nozzles { get; set; } = new();
        public int? iProcessConditionId => iProcessCondition?.Id == 0 ? null : iProcessCondition?.Id;
        public EditProcessCondition? iProcessCondition { get; set; } = new();
        public int? iProcessFluidId => iProcessFluid?.Id == 0 ? null : iProcessFluid?.Id;
        public EditProcessFluid? iProcessFluid { get; set; } = new();
        [Report(Order = 3)]
        public string ProcessFluidName => iProcessFluid == null ? "" : iProcessFluid!.Name;
        public int? iGasketId => iGasket?.Id == 0 ? null : iGasket?.Id;
        public EditGasket? iGasket { get; set; } = new();
        [Report(Order = 4)]
        public string GasketName => iGasket == null ? "" : iGasket!.Name;
        public int? iInnerMaterialId => iInnerMaterial?.Id == 0 ? null : iInnerMaterial?.Id;
        public EditMaterial? iInnerMaterial { get; set; } = new();
        [Report(Order = 5)]
        public string InnerMaterialName => iInnerMaterial == null ? "" : iInnerMaterial!.Name;
        public int? iOuterMaterialId => iOuterMaterial?.Id == 0 ? null : iOuterMaterial?.Id;
        public EditMaterial? iOuterMaterial { get; set; } = new();
        [Report(Order = 6)]
        public string OuterMaterialName => iOuterMaterial == null ? "" : iOuterMaterial!.Name;
        public int? MeasuredVariableId => MeasuredVariable?.Id == 0 ? null : MeasuredVariable?.Id;
        public EditMeasuredVariable? MeasuredVariable { get; set; } = new();
        [Report(Order = 7)]
        public string MeasuredVariableName => MeasuredVariable == null ? "" : MeasuredVariable!.Name;
        public int? MeasuredVariableModifierId => MeasuredVariableModifier?.Id == 0 ? null : MeasuredVariableModifier?.Id;
        public EditMeasuredVariableModifier? MeasuredVariableModifier { get; set; } = new();
        [Report(Order = 8)]
        public string MeasuredVariableModifierName => MeasuredVariableModifier == null ? "" : MeasuredVariableModifier!.Name;
        public int? DeviceFunctionId => DeviceFunction?.Id == 0 ? null : DeviceFunction?.Id;
        public EditDeviceFunction? DeviceFunction { get; set; } = new();
        [Report(Order = 9)]
        public string DeviceFunctionName => DeviceFunction == null ? "" : DeviceFunction!.Name;
        public int? DeviceFunctionModifierId => DeviceFunctionModifier?.Id == 0 ? null : DeviceFunctionModifier?.Id;
        public EditDeviceFunctionModifier? DeviceFunctionModifier { get; set; } = new();
        [Report(Order = 10)]
        public string DeviceFunctionModifierName => DeviceFunctionModifier == null ? "" : DeviceFunctionModifier!.Name;
        public int? ReadoutId => Readout?.Id == 0 ? null : Readout?.Id;
        public EditReadout? Readout { get; set; } = new();
        [Report(Order = 11)]
        public string ReadoutName => Readout == null ? "" : Readout!.Name;

        public int? iBrandId => iBrand?.Id == 0 ? null : iBrand?.Id;
        public EditBrand? iBrand { get; set; } = new();
        [Report(Order = 12)]
        public string BrandName => iBrand == null ? "" : iBrand!.Name;
        public int? iSupplierId => iSupplier?.Id == 0 ? null : iSupplier?.Id;
        public EditSupplier? iSupplier { get; set; } = new();
        [Report(Order = 13)]
        public string SupplierName => iSupplier == null ? "" : iSupplier!.Name;
      
        public string TagId => SetTagId();
      
        public string? TagLetter => SetTagLetter();

        public string? TagNumber { get; set; } = "";
        [Report(Order = 14)]
        public string? Model { get; set; } = "";
        [Report(Order = 15)]
        public string? Reference { get; set; } = "";
        [Report(Order = 16)]
        public string? SerialNumber { get; set; } = "";
        
        string SetTagLetter()
        {
            if (MeasuredVariable == null) return "";
          
            string tag = $"{MeasuredVariable?.TagLetter}{MeasuredVariableModifier?.TagLetter}{Readout?.TagLetter}{DeviceFunction?.TagLetter}{DeviceFunctionModifier?.TagLetter}";

            return tag;
        }
        string SetTagId()
        {
            if (TagLetter == "") return "";
            if (TagNumber == "") return $"{TagLetter}";
            return $"{TagLetter}_{TagNumber}";

           
        }
    }

}
