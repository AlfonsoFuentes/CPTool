using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate
{
    public class AddProcessCondition
    {

       
        public string Name { get; set; } = string.Empty;
        public AddUnit? Pressure { get; set; }
        public AddUnit? Temperature { get; set; }
        public AddUnit? MassFlow { get; set; }
        public AddUnit? VolumetricFlow { get; set; }
        public AddUnit? Density { get; set; }
        public AddUnit? Viscosity { get; set; }
        public AddUnit? EnthalpyFlow { get; set; }
        public AddUnit? SpecificEnthalpy { get; set; }
        public AddUnit? ThermalConductivity { get; set; }
        public AddUnit? SpecificCp { get; set; }

    }

}
