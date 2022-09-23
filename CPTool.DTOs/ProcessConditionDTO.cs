using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class ProcessConditionDTO : AuditableEntityDTO, IMapFrom<ProcessCondition>
    {

        public List<PipeAccesoryDTO>? PipeAccesorysDTO { get; set; } = null!;
        public List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = null!;
        public List<InstrumentItemDTO>? InstrumentItemsDTO { get; set; } = null!;
        public UnitDTO? PressureDTO { get; set; } = new(PressureUnits.Bar);
        public UnitDTO? TemperatureDTO { get; set; } = new(TemperatureUnits.DegreeCelcius);
        public UnitDTO? MassFlowDTO { get; set; } = new(MassFlowUnits.Kg_hr);
        public UnitDTO? VolumetricFlowDTO { get; set; } = new(VolumetricFlowUnits.m3_hr);
        public UnitDTO? DensityDTO { get; set; } = new(MassDensityUnits.Kg_m3);
        public UnitDTO? ViscosityDTO { get; set; } = new(ViscosityUnits.cPoise);
        public UnitDTO? EnthalpyFlowDTO { get; set; } = new(EnergyFlowUnits.Kcal_hr);
        public UnitDTO? SpecificEnthalpyDTO { get; set; } = new(MassEnergyUnits.Kcal_Kg);
        public UnitDTO? ThermalConductivityDTO { get; set; } = new(ThermalConductivityUnits.kW_m_K);
        public UnitDTO? SpecificCpDTO { get; set; } = new(MassEntropyUnits.Kcal_Kg_C);
        
    }
}
