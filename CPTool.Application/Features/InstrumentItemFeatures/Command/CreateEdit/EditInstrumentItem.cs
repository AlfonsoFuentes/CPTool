





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
    public class EditInstrumentItem : EditCommand, IRequest<Result<int>>
    {
        //public int? ProcessConditionId => ProcessCondition.Id == 0 ? null : ProcessCondition.Id;
        public EditProcessCondition? ProcessCondition { get; set; } = new();
        //public int? ProcessFluidId => ProcessFluid == null ? null : ProcessFluid.Id;
        public EditProcessFluid? ProcessFluid { get; set; } = new();
        public List<EditNozzle>? Nozzles { get; set; } = new();

        //public int? GasketId => Gasket == null ? null : Gasket.Id;
        public EditGasket? Gasket { get; set; } = new();
        //public int? iInnerMaterialId => iInnerMaterial == null ? null : iInnerMaterial.Id;
        public EditMaterial? iInnerMaterial { get; set; } = new();
        //public int? iOuterMaterialId => iOuterMaterial == null ? null : iOuterMaterial.Id;
        public EditMaterial? iOuterMaterial { get; set; } = new();
        //public int? MeasuredVariableId => MeasuredVariable == null ? null : MeasuredVariable.Id;
        public EditMeasuredVariable? MeasuredVariable { get; set; } = new();
        //public int? MeasuredVariableModifierId => MeasuredVariableModifier == null ? null : MeasuredVariableModifier.Id;
        public EditMeasuredVariableModifier? MeasuredVariableModifier { get; set; } = new();
        //public int? DeviceFunctionId => DeviceFunction == null ? null : DeviceFunction.Id;
        public EditDeviceFunction? DeviceFunction { get; set; } = new();
        //public int? DeviceFunctionModifierId => DeviceFunctionModifier == null ? null : DeviceFunctionModifier.Id;
        public EditDeviceFunctionModifier? DeviceFunctionModifier { get; set; } = new();
        //public int? ReadoutId => Readout == null ? null : Readout.Id;
        public EditReadout? Readout { get; set; } = new();

        //public int? BrandId => Brand == null ? null : Brand.Id;
        public AddBrand? Brand { get; set; } = new();
        //public int? SupplierId => Supplier == null ? null : Supplier.Id;
        public EditSupplier? Supplier { get; set; } = new();
        public string TagId { get; set; } = String.Empty;
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }

       
    }

}
