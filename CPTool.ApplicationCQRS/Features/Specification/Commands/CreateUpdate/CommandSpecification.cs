using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate
{
    public class CommandSpecification : CommandBase, IRequest<SpecificationCommandResponse>
    {
        public int? EquipmentTypeId => EquipmentType!.Id==0?null:EquipmentType.Id;
        public CommandEquipmentType? EquipmentType { get; set; } = new();

        public int? EquipmentTypeSubId => EquipmentTypeSub!.Id == 0 ? null : EquipmentTypeSub!.Id;
        public CommandEquipmentTypeSub? EquipmentTypeSub { get; set; }

        public CommandDeviceFunction? DeviceFunction { get; set; } = new();
        public int? DeviceFunctionId => DeviceFunction!.Id == 0 ? null : DeviceFunction!.Id;

        public CommandDeviceFunctionModifier? DeviceFunctionModifier { get; set; } = new();

        public int? DeviceFunctionModifierId => DeviceFunctionModifier!.Id == 0 ? null : DeviceFunctionModifier!.Id;

        public CommandMeasuredVariable? MeasuredVariable { get; set; } = new();
        public int? MeasuredVariableId => MeasuredVariable!.Id == 0 ? null : MeasuredVariable!.Id;

        public CommandMeasuredVariableModifier? MeasuredVariableModifier { get; set; } = new();
        public int? MeasuredVariableModifierId => MeasuredVariableModifier!.Id == 0 ? null : MeasuredVariableModifier!.Id;

        public CommandReadout? Readout { get; set; } = new();
        public int? ReadoutId => EquipmentType.Id == 0 ? null : EquipmentType.Id;

        public HashSet<CommandPropertySpecification>? PropertySpecifications { get; set; } = new();

    }

}
