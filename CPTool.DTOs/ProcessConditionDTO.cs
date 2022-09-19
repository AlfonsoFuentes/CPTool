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
        public UnitDTO? PressureDTO { get; set; } = new() { Amount = new Pressure(PressureUnits.Bar) };
        public UnitDTO? TemperatureDTO { get; set; } = new() { Amount = new Temperature(TemperatureUnits.DegreeCelcius) };
        public UnitDTO? MassFlowDTO { get; set; } = new() { Amount = new MassFlow(MassFlowUnits.Kg_hr) };
        public UnitDTO? VolumetricFlowDTO { get; set; } = new() { Amount = new VolumetricFlow(VolumetricFlowUnits.m3_hr) };
        public UnitDTO? DensityDTO { get; set; } = new() { Amount = new MassDensity(MassDensityUnits.Kg_m3) };
        public UnitDTO? ViscosityDTO { get; set; } = new() { Amount = new Viscosity(ViscosityUnits.cPoise) };
        public UnitDTO? EnthalpyFlowDTO { get; set; } = new() { Amount = new EnergyFlow(EnergyFlowUnits.Kcal_hr) };
        public UnitDTO? SpecificEnthalpyDTO { get; set; } = new() { Amount = new MassEnergy(MassEnergyUnits.Kcal_Kg) };
        public UnitDTO? ThermalConductivityDTO { get; set; } = new() { Amount = new ThermalConductivity(ThermalConductivityUnits.kW_m_K) };
        public UnitDTO? SpecificCpDTO { get; set; } = new() { Amount = new MassEntropy(MassEntropyUnits.Kcal_Kg_C) };
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
