





using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.Domain.Entities;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    public class AddPipeAccesory : AddCommand
    {
        public int? pPipingItemId { get; set; }
        public AddProcessCondition? pProcessCondition { get; set; }

        public int? paProcessFluidId { get; set; }

        public AddUnit? Friction { get; set; }
        public AddUnit? Reynold { get; set; }
        public AddUnit? LevelInlet { get; set; }
        public AddUnit? LevelOutlet { get; set; }
        public AddUnit? FrictionDropPressure { get; set; }
        public AddUnit? OverallDropPressure { get; set; }
        public AddUnit? ElevationChange { get; set; }


        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

        public int? paMaterialId { get; set; }
        public int? paDiameterId { get; set; }
        public int? paPipeClassId { get; set; }




    }

}
