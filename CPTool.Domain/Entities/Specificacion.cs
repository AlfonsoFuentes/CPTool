using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Domain.Entities
{
    public class Specification : AuditableEntity
    {

        public int? EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; }

        public int? EquipmentTypeSubId { get; set; }
        public EquipmentTypeSub? EquipmentTypeSub { get; set; }

        public DeviceFunction? DeviceFunction { get; set; }
        public int? DeviceFunctionId { get; set; }

        public DeviceFunctionModifier? DeviceFunctionModifier { get; set; }

        public int? DeviceFunctionModifierId { get; set; }

        public MeasuredVariable? MeasuredVariable { get; set; }
        public int? MeasuredVariableId { get; set; }

        public MeasuredVariableModifier? MeasuredVariableModifier { get; set; }
        public int? MeasuredVariableModifierId { get; set; }

        public Readout? Readout { get; set; }
        public int? ReadoutId { get; set; }

        public ICollection<PropertySpecification>? PropertySpecifications { get; set; }
    }
}
