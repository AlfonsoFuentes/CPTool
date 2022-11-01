using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Query.GetById;
using CPTool.Application.Features.NozzleFeatures.Query.GetList;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetById;
using CPTool.Application.Features.PipeAccesoryFeatures.Query.GetList;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    public class EditPipeAccesory : EditCommand, IRequest<Result<int>>
    {
         public int? pPipingItemId => pPipingItem?.Id == 0 ? null : pPipingItem?.Id;
        public EditPipingItem? pPipingItem { get; set; } = new();
        public int? pProcessConditionId => pProcessCondition == null ? null : pProcessCondition?.Id;
        public EditProcessCondition? pProcessCondition { get; set; } = new();

        public int? paProcessFluidId => paProcessFluid == null ? null : paProcessFluid?.Id;
        public EditProcessFluid? paProcessFluid { get; set; } = null;
        public int? FrictionId => Friction == null ? null : Friction?.Id;
        public EditUnit? Friction { get; set; } = new(UnitLessUnits.None);
        public int? ReynoldId => Reynold == null ? null : Reynold?.Id;
        public EditUnit? Reynold { get; set; } = new(UnitLessUnits.None);
        public int? LevelInletId => LevelInlet == null ? null : LevelInlet?.Id;
        public EditUnit? LevelInlet { get; set; } = new(LengthUnits.MilliMeter);
        public int? LevelOutletId => LevelOutlet == null ? null : LevelOutlet?.Id;
        public EditUnit? LevelOutlet { get; set; } = new(LengthUnits.MilliMeter);
        public int? FrictionDropPressureId => FrictionDropPressure == null ? null : FrictionDropPressure?.Id;
        public EditUnit? FrictionDropPressure { get; set; } = new(PressureDropUnits.psi);
        public int? OverallDropPressureId => OverallDropPressure == null ? null : OverallDropPressure?.Id;
        public EditUnit? OverallDropPressure { get; set; } = new(PressureDropUnits.psi);
        public int? ElevationChangeId => ElevationChange == null ? null : ElevationChange?.Id;
        public EditUnit? ElevationChange { get; set; } = new(PressureDropUnits.psi);


        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

      
        public override T AddDetailtoMaster<T>()
        {
            T detail = new();
            (detail as EditNozzle)!.PipeAccesory = this;
            return detail!;
        }
    }

}
