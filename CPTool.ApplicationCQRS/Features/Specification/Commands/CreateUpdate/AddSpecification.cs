using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate
{
    public class AddSpecification
    {

        public int? EquipmentTypeId { get; set; }

        public int? EquipmentTypeSubId { get; set; }

 
        public int? DeviceFunctionId { get; set; }

        public int? DeviceFunctionModifierId { get; set; }
        public int? MeasuredVariableId { get; set; }
        public int? MeasuredVariableModifierId { get; set; }
        public int? ReadoutId { get; set; }

        public HashSet<AddPropertySpecification>? PropertySpecifications { get; set; } = new();
        public string Name { get; set; } = string.Empty;

    }

}
