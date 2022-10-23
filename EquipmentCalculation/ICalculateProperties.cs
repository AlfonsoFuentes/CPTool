using CPTool.UnitsSystem;

namespace EquipmentCalculation
{
    public interface ICalculateProperties
    {
        public Amount Pressure { get; set; } 

        public Amount Temperature { get; set; } 

        public Amount MassFlow { get; set; }

        public Amount VolumetricFlow { get; set; }

        public Amount Density { get; set; } 

        public Amount Viscosity { get; set; } 

        public Amount EnthalpyFlow { get; set; }

        public Amount SpecificEnthalpy { get; set; }
        public Amount ThermalConductivity { get; set; }
        public Amount SpecificEntropy { get; set; }
        public Amount SpecificCp { get; set; } 
        public void CalculateProperties();

        public void CalculateVolumetricFlow();
        public void CalculateMassFlow();
        public void CalculateEnthalpyFlow();

    }
}