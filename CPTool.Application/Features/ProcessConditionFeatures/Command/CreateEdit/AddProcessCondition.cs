





using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.ProcessConditionFeatures.CreateEdit
{
    public class AddProcessCondition : AddCommand
    {
       
       
        
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
