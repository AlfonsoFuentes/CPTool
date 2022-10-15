





using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.ProcessConditionFeatures.CreateEdit
{
    public class AddProcessCondition : AddCommand, IRequest<Result<int>>
    {
        public AddProcessCondition()
        {

            Temperature.Name = "Temperature";
            Pressure.Name = "Pressure";
            MassFlow.Name = "Mass Flow";
            VolumetricFlow.Name = "Pressure";
            Density.Name = "Density";
            Viscosity.Name = "Viscosity";
            EnthalpyFlow.Name = "Enthalpy Flow";
            SpecificEnthalpy.Name = "Specific Enthalpy";
            ThermalConductivity.Name = "Thermal Conductivity";

        }
       
        //public int? PressureId => Pressure.Id == 0 ? null : Pressure.Id;
        public AddUnit Pressure { get; set; } = new(PressureUnits.Bar);
        //public int? TemperatureId => Temperature.Id == 0 ? null : Temperature.Id;
        public AddUnit Temperature { get; set; } = new(TemperatureUnits.DegreeCelcius);
        //public int? MassFlowId => MassFlow.Id == 0 ? null : MassFlow.Id;
        public AddUnit MassFlow { get; set; } = new(MassFlowUnits.Kg_hr);
        //public int? VolumetricFlowId => VolumetricFlow.Id == 0 ? null : VolumetricFlow.Id;
        public AddUnit VolumetricFlow { get; set; } = new(VolumetricFlowUnits.m3_hr);
        //public int? DensityId => Density.Id == 0 ? null : Density.Id;
        public AddUnit Density { get; set; } = new(MassDensityUnits.Kg_m3);
        //public int? ViscosityId => Viscosity.Id == 0 ? null : Viscosity.Id;
        public AddUnit Viscosity { get; set; } = new(ViscosityUnits.cPoise);
        //public int? EnthalpyFlowId => EnthalpyFlow.Id == 0 ? null : EnthalpyFlow.Id;
        public AddUnit EnthalpyFlow { get; set; } = new(EnergyFlowUnits.Kcal_hr);
        //public int? SpecificEnthalpyId => SpecificEnthalpy.Id == 0 ? null : SpecificEnthalpy.Id;
        public AddUnit SpecificEnthalpy { get; set; } = new(MassEnergyUnits.Kcal_Kg);
        //public int? ThermalConductivityId => ThermalConductivity.Id == 0 ? null : ThermalConductivity.Id;
        public AddUnit ThermalConductivity { get; set; } = new(ThermalConductivityUnits.kW_m_K);
        //public int? SpecificCpId => SpecificCp.Id == 0 ? null : SpecificCp.Id;
        public AddUnit SpecificCp { get; set; } = new(MassEntropyUnits.Kcal_Kg_C);


    }
}
