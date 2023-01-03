using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate
{
    public class CommandInstrumentItem : CommandBase, IRequest<InstrumentItemCommandResponse>
    {
        public CommandMWOItem MWOItem { get; set; } = new();
        public List<CommandNozzle>? Nozzles { get; set; } = new();
        public int? iProcessConditionId => iProcessCondition?.Id == 0 ? null : iProcessCondition?.Id;
        public CommandProcessCondition? iProcessCondition { get; set; } = new();
        public int? iProcessFluidId => iProcessFluid?.Id == 0 ? null : iProcessFluid?.Id;
        public CommandProcessFluid? iProcessFluid { get; set; } = new();

        public string ProcessFluidName => iProcessFluid == null ? "" : iProcessFluid!.Name;
        public int? iGasketId => iGasket?.Id == 0 ? null : iGasket?.Id;
        public CommandGasket? iGasket { get; set; } = new();

        public string GasketName => iGasket == null ? "" : iGasket!.Name;
        public int? iInnerMaterialId => iInnerMaterial?.Id == 0 ? null : iInnerMaterial?.Id;
        public CommandMaterial? iInnerMaterial { get; set; } = new();

        public string InnerMaterialName => iInnerMaterial == null ? "" : iInnerMaterial!.Name;
        public int? iOuterMaterialId => iOuterMaterial?.Id == 0 ? null : iOuterMaterial?.Id;
        public CommandMaterial? iOuterMaterial { get; set; } = new();

        public string OuterMaterialName => iOuterMaterial == null ? "" : iOuterMaterial!.Name;
        public int? MeasuredVariableId => MeasuredVariable?.Id == 0 ? null : MeasuredVariable?.Id;
        CommandMeasuredVariable? _MeasuredVariable = new();
        public CommandMeasuredVariable? MeasuredVariable
        {
            get { return _MeasuredVariable; }
            set
            {
                _MeasuredVariable = value;
                _TagLetter = SetTagLetter();
                _TagId = SetTagId();


            }
        }

        public string MeasuredVariableName => MeasuredVariable == null ? "" : MeasuredVariable!.Name;
        public int? MeasuredVariableModifierId => MeasuredVariableModifier?.Id == 0 ? null : MeasuredVariableModifier?.Id;
        CommandMeasuredVariableModifier? _MeasuredVariableModifier = new();
        public CommandMeasuredVariableModifier? MeasuredVariableModifier
        {
            get { return _MeasuredVariableModifier; }
            set
            {
                _MeasuredVariableModifier = value;
                _TagLetter = SetTagLetter();
                _TagId = SetTagId();


            }
        }

        public string MeasuredVariableModifierName => MeasuredVariableModifier == null ? "" : MeasuredVariableModifier!.Name;
        public int? DeviceFunctionId => DeviceFunction?.Id == 0 ? null : DeviceFunction?.Id;
        CommandDeviceFunction? _DeviceFunction = new();
        public CommandDeviceFunction? DeviceFunction
        {
            get { return _DeviceFunction; }
            set
            {
                _DeviceFunction = value;
                _TagLetter = SetTagLetter();
                _TagId = SetTagId();


            }
        }

        public string DeviceFunctionName => DeviceFunction == null ? "" : DeviceFunction!.Name;
        public int? DeviceFunctionModifierId => DeviceFunctionModifier?.Id == 0 ? null : DeviceFunctionModifier?.Id;
        CommandDeviceFunctionModifier? _DeviceFunctionModifier = new();
        public CommandDeviceFunctionModifier? DeviceFunctionModifier
        {
            get { return _DeviceFunctionModifier; }
            set
            {
                _DeviceFunctionModifier = value;
                _TagLetter = SetTagLetter();
                _TagId = SetTagId();


            }
        }

        public string DeviceFunctionModifierName => DeviceFunctionModifier == null ? "" : DeviceFunctionModifier!.Name;
        public int? ReadoutId => Readout?.Id == 0 ? null : Readout?.Id;
        CommandReadout? _Readout = new();
        public CommandReadout? Readout
        {
            get { return _Readout; }
            set
            {
                _Readout = value;
                _TagLetter = SetTagLetter();
                _TagId = SetTagId();


            }
        }

        public string ReadoutName => Readout == null ? "" : Readout!.Name;

        public int? iBrandId => iBrand?.Id == 0 ? null : iBrand?.Id;
        public CommandBrand? iBrand { get; set; } = new();

        public string BrandName => iBrand == null ? "" : iBrand!.Name;
        public int? iSupplierId => iSupplier?.Id == 0 ? null : iSupplier?.Id;
        public CommandSupplier? iSupplier { get; set; } = new();

        public string SupplierName => iSupplier == null ? "" : iSupplier!.Name;
        string _TagId = string.Empty;

        string? _TagLetter = string.Empty;
        public string? TagLetter { get => _TagLetter; set => _TagLetter = value; }
        public string TagId { get => _TagId; set => _TagId = value; }
        string _TagNumber = string.Empty;
        public string TagNumber
        {
            get { return _TagNumber; }
            set
            {
                _TagNumber = value;
                _TagId = SetTagId();
            }
        }

        public string? Model { get; set; } = "";

        public string? Reference { get; set; } = "";

        public string? SerialNumber { get; set; } = "";

        string SetTagLetter()
        {
            if (MeasuredVariable == null) return "";
            if (MeasuredVariableModifier == null) return $"{MeasuredVariable?.TagLetter}";
            if (Readout == null) return $"{MeasuredVariable?.TagLetter}{MeasuredVariableModifier?.TagLetter}";
            if (DeviceFunction == null) return $"{MeasuredVariable?.TagLetter}{MeasuredVariableModifier?.TagLetter}{Readout?.TagLetter}";
            if (DeviceFunctionModifier == null) return $"{MeasuredVariable?.TagLetter}{MeasuredVariableModifier?.TagLetter}{Readout?.TagLetter}{DeviceFunction?.TagLetter}";

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
