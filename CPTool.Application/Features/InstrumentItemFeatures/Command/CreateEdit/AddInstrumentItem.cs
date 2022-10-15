





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

namespace CPTool.Application.Features.InstrumentItemFeatures.CreateEdit
{
    public class AddInstrumentItem : AddCommand, IRequest<Result<int>>
    {
      
        public AddProcessCondition ProcessCondition { get; set; } = new();
        public int? ProcessFluidId => ProcessFluidCommand?.Id==0 ? null : ProcessFluidCommand?.Id;
        public EditProcessFluid? ProcessFluidCommand { get; set; } = new();


        public int? GasketId => GasketCommand?.Id==0 ? null : GasketCommand?.Id;
        public EditGasket? GasketCommand { get; set; } = new();
        public int? iInnerMaterialId => iInnerMaterialCommand?.Id==0 ? null : iInnerMaterialCommand?.Id;
        public EditMaterial? iInnerMaterialCommand { get; set; } = new();
        public int? iOuterMaterialId => iOuterMaterialCommand?.Id==0 ? null : iOuterMaterialCommand?.Id;
        public EditMaterial? iOuterMaterialCommand { get; set; } = new();
        public int? MeasuredVariableId => MeasuredVariableCommand?.Id==0 ? null : MeasuredVariableCommand?.Id;
        public EditMeasuredVariable? MeasuredVariableCommand { get; set; } = new();
        public int? MeasuredVariableModifierId => MeasuredVariableModifierCommand?.Id==0 ? null : MeasuredVariableModifierCommand?.Id;
        public EditMeasuredVariableModifier? MeasuredVariableModifierCommand { get; set; } = new();
        public int? DeviceFunctionId => DeviceFunctionCommand?.Id==0 ? null : DeviceFunctionCommand?.Id;
        public EditDeviceFunction? DeviceFunctionCommand { get; set; } = new();
        public int? DeviceFunctionModifierId => DeviceFunctionModifierCommand?.Id==0 ? null : DeviceFunctionModifierCommand?.Id;
        public EditDeviceFunctionModifier? DeviceFunctionModifierCommand { get; set; } = new();
        public int? ReadoutId => ReadoutCommand?.Id==0 ? null : ReadoutCommand?.Id;
        public EditReadout? ReadoutCommand { get; set; } = new();

        public int? BrandId => BrandCommand?.Id==0 ? null : BrandCommand?.Id;
        public EditBrand? BrandCommand { get; set; } = new();
        public int? SupplierId => SupplierCommand?.Id==0 ? null : SupplierCommand?.Id;
        public EditSupplier? SupplierCommand { get; set; } = new();
        public string TagId { get; set; }=String.Empty;
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }

       
    }

}
