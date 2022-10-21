





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
        public List<EditNozzle>? Nozzles { get; set; }
        public int? iProcessConditionId => iProcessCondition?.Id == 0 ? null : iProcessCondition?.Id;
        public EditProcessCondition? iProcessCondition { get; set; } = new();
        public int? iProcessFluidId => iProcessFluid?.Id == 0 ? null : iProcessFluid?.Id;
        public EditProcessFluid? iProcessFluid { get; set; } = new();
         public int? iGasketId => iGasket?.Id == 0 ? null : iGasket?.Id;
        public EditGasket? iGasket { get; set; } = new();
        public int? iInnerMaterialId => iInnerMaterial?.Id == 0 ? null : iInnerMaterial?.Id;
        public EditMaterial? iInnerMaterial { get; set; } = new();
        public int? iOuterMaterialId => iOuterMaterial?.Id == 0 ? null : iOuterMaterial?.Id;
        public EditMaterial? iOuterMaterial { get; set; } = new();
        public int? MeasuredVariableId => MeasuredVariable?.Id == 0 ? null : MeasuredVariable?.Id;
        public EditMeasuredVariable? MeasuredVariable { get; set; } = new();
        public int? MeasuredVariableModifierId => MeasuredVariableModifier?.Id == 0 ? null : MeasuredVariableModifier?.Id;
        public EditMeasuredVariableModifier? MeasuredVariableModifier { get; set; } = new();
        public int? DeviceFunctionId => DeviceFunction?.Id == 0 ? null : DeviceFunction?.Id;
        public EditDeviceFunction? DeviceFunction { get; set; } = new();
        public int? DeviceFunctionModifierId => DeviceFunctionModifier?.Id == 0 ? null : DeviceFunctionModifier?.Id;
        public EditDeviceFunctionModifier? DeviceFunctionModifier { get; set; } = new();
        public int? ReadoutId => Readout?.Id == 0 ? null : Readout?.Id;
        public EditReadout? Readout { get; set; } = new();

        public int? iBrandId => iBrand?.Id == 0 ? null : iBrand?.Id;
        public EditBrand? iBrand { get; set; } = new();
        public int? iSupplierId => iSupplier?.Id == 0 ? null : iSupplier?.Id;
        public EditSupplier? iSupplier { get; set; } = new();
        public string TagId => SetTagId();
        public string? TagLetter => SetTagLetter();
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }
        public override T AddDetailtoMaster<T>()
        {
            if (typeof(T) == typeof(EditNozzle))
            {
                EditNozzle detail = new();

                detail.Order = Nozzles!.Count == 0 ? 1 : this.Nozzles.OrderBy(x => x.Order).Last().Order + 1;
                detail.Name = $"N{detail.Order}";
                detail.InstrumentItem = this;
                Nozzles.Add(detail);


                return (detail as T)!;
            }
            return null!;
        }
        string SetTagLetter()
        {
            string tag = $"{MeasuredVariable?.TagLetter}{MeasuredVariableModifier?.TagLetter}{Readout?.TagLetter}{DeviceFunction?.TagLetter}{DeviceFunctionModifier?.TagLetter}";

            return tag;
        }
        string SetTagId()
        {
            var tag = $"{TagLetter}_{TagNumber}";

            return tag;
        }
    }

}
