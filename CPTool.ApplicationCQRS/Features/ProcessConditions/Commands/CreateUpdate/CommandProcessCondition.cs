using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.UnitsSystem;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate
{
    public class CommandProcessCondition : CommandBase, IRequest<ProcessConditionCommandResponse>
    {

        public CommandProcessCondition()
        {

            Temperature.Name = "Temperature";
            Pressure.Name = "Pressure";
            MassFlow.Name = "Mass Flow";
            VolumetricFlow.Name = "Volumetric flow";
            Density.Name = "Density";
            Viscosity.Name = "Viscosity";
            EnthalpyFlow.Name = "Enthalpy flow";
            SpecificEnthalpy.Name = "Specific enthalpy";
            ThermalConductivity.Name = "Thermal conductivity";
            SpecificCp.Name = "Specific heat capacity";

        }

        public int? PressureId => Pressure?.Id == 0 ? null : Pressure?.Id;
        public CommandUnit? Pressure { get; set; } = new(PressureUnits.Bar);
        public int? TemperatureId => Temperature?.Id == 0 ? null : Temperature?.Id;
        public CommandUnit? Temperature { get; set; } = new(TemperatureUnits.DegreeCelcius);
        public int? MassFlowId => MassFlow?.Id == 0 ? null : MassFlow?.Id;
        public CommandUnit? MassFlow { get; set; } = new(MassFlowUnits.Kg_hr);
        public int? VolumetricFlowId => VolumetricFlow?.Id == 0 ? null : VolumetricFlow?.Id;
        public CommandUnit? VolumetricFlow { get; set; } = new(VolumetricFlowUnits.m3_hr);
        public int? DensityId => Density?.Id == 0 ? null : Density?.Id;
        public CommandUnit? Density { get; set; } = new(MassDensityUnits.Kg_m3);
        public int? ViscosityId => Viscosity?.Id == 0 ? null : Viscosity?.Id;
        public CommandUnit? Viscosity { get; set; } = new(ViscosityUnits.cPoise);
        public int? EnthalpyFlowId => EnthalpyFlow?.Id == 0 ? null : EnthalpyFlow?.Id;
        public CommandUnit? EnthalpyFlow { get; set; } = new(EnergyFlowUnits.Kcal_hr);
        public int? SpecificEnthalpyId => SpecificEnthalpy?.Id == 0 ? null : SpecificEnthalpy?.Id;
        public CommandUnit? SpecificEnthalpy { get; set; } = new(MassEnergyUnits.Kcal_Kg);
        public int? ThermalConductivityId => ThermalConductivity?.Id == 0 ? null : ThermalConductivity?.Id;
        public CommandUnit? ThermalConductivity { get; set; } = new(ThermalConductivityUnits.kW_m_K);
        public int? SpecificCpId => SpecificCp?.Id == 0 ? null : SpecificCp?.Id;
        public CommandUnit? SpecificCp { get; set; } = new(MassEntropyUnits.Kcal_Kg_C);

        public CommandProcessFluid ProcessFluid { get; set; } = new();


    }

}
