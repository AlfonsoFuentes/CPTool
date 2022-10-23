using CPTool.UnitsSystem;

namespace EquipmentCalculation
{
    public abstract class PropertyPackageCalculator : ICalculateProperties
    {
        public PropertyPackageCalculator() { }

        public Amount Pressure { get; set; } = new(PressureUnits.Bar);

        public Amount Temperature { get; set; } = new(TemperatureUnits.DegreeCelcius);

        public Amount MassFlow { get; set; } = new(MassFlowUnits.Kg_hr);

        public Amount VolumetricFlow { get; set; } = new(VolumetricFlowUnits.m3_hr);

        public Amount Density { get; set; } = new(MassDensityUnits.Kg_m3);

        public Amount Viscosity { get; set; } = new(ViscosityUnits.cPoise);

        public Amount EnthalpyFlow { get; set; } = new(EnergyFlowUnits.Kcal_hr);
        public Amount SpecificEntropy { get; set; } = new(MassEntropyUnits.Kcal_Kg_C);
        public Amount SpecificEnthalpy { get; set; } = new(MassEnergyUnits.Kcal_Kg);
        public Amount ThermalConductivity { get; set; } = new(ThermalConductivityUnits.kW_m_K);

        public Amount SpecificCp { get; set; } = new(MassEntropyUnits.Kcal_Kg_C);

        public abstract void CalculateProperties();

        public abstract void CalculateVolumetricFlow();

        public abstract void CalculateMassFlow();

        public abstract void CalculateEnthalpyFlow();
    }
}