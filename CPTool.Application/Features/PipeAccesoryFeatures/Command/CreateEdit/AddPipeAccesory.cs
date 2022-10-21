





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    public class AddPipeAccesory : AddCommand
    {
        public int? pPipingItemId { get; set; }
        public EditProcessCondition? pProcessCondition { get; set; }

        public int? paProcessFluidId { get; set; }

        public EditUnit? Friction { get; set; }
        public EditUnit? Reynold { get; set; }
        public EditUnit? LevelInlet { get; set; }
        public EditUnit? LevelOutlet { get; set; }
        public EditUnit? FrictionDropPressure { get; set; }
        public EditUnit? OverallDropPressure { get; set; }
        public EditUnit? ElevationChange { get; set; }


        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }




    }

}
