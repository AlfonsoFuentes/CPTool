using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class ProcessConditionDTO : AuditableEntityDTO
    {

        public List<PipeAccesoryDTO>? PipeAccesorysDTO { get; set; } = new();
        public List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = new();
        public List<InstrumentItemDTO>? InstrumentItemsDTO { get; set; } = new();
        public UnitDTO? PressureDTO { get; set; }
        public UnitDTO? TemperatureDTO { get; set; }
        public UnitDTO? MassFlowDTO { get; set; }
        public UnitDTO? VolumetricFlowDTO { get; set; }
        public UnitDTO? DensityDTO { get; set; }
        public UnitDTO? ViscosityDTO { get; set; }
        public UnitDTO? EnthalpyFlowDTO { get; set; }
        public UnitDTO? SpecificEnthalpyDTO { get; set; }
        public UnitDTO? ThermalConductivityDTO { get; set; }
        public UnitDTO? SpecificCpDTO { get; set; }
        public ProcessFluid? ProcessFluidDTO { get; set; }
        public int? PressureId=>PressureDTO?.Id;
        public int? TemperatureId=> TemperatureDTO?.Id;
        public int? MassFlowId=> MassFlowDTO?.Id;
        public int? VolumetricFlowId=> VolumetricFlowDTO?.Id;
        public int? DensityId=> DensityDTO?.Id;
        public int? ViscosityId=> ViscosityDTO?.Id;
        public int? EnthalpyFlowId=> EnthalpyFlowDTO?.Id;
        public int? SpecificEnthalpyId=> SpecificEnthalpyDTO?.Id;
        public int? ThermalConductivityId=> ThermalConductivityDTO?.Id;
        public int? SpecificCpId=> SpecificCpDTO?.Id;
        public int? ProcessFluidId=> ProcessFluidDTO?.Id;
    }
}
