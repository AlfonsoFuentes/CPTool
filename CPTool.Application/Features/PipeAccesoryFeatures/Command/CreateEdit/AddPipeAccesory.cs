





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipingItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit
{
    public class AddPipeAccesory : AddCommand, IRequest<Result<int>>
    {
        public int? PipingItemId => PipingItemCommand?.Id==0 ? null : PipingItemCommand?.Id;
        public EditPipingItem? PipingItemCommand { get; set; } = new();
       
        public EditProcessCondition? ProcessCondition { get; set; } = new();

        public int? ProcessFluidId => ProcessFluidCommand?.Id==0 ? null : ProcessFluidCommand?.Id;
        public EditProcessFluid? ProcessFluidCommand { get; set; } =new();
        //public int? FrictionId => FrictionCommand?.Id==0 ? null : Friction?.Id;
        public EditUnit? Friction { get; set; } = new(UnitLessUnits.None);
        //public int? ReynoldId => ReynoldCommand?.Id==0 ? null : Reynold?.Id;
        public EditUnit? Reynold { get; set; } = new(UnitLessUnits.None);
        //public int? LevelInletId => LevelInletCommand?.Id==0 ? null : LevelInlet?.Id;
        public EditUnit? LevelInlet { get; set; } = new(LengthUnits.MilliMeter);
        //public int? LevelOutletId => LevelOutletCommand?.Id==0 ? null : LevelOutlet?.Id;
        public EditUnit? LevelOutlet { get; set; } = new(LengthUnits.MilliMeter);
        //public int? FrictionDropPressureId => FrictionDropPressureCommand?.Id==0 ? null : FrictionDropPressure?.Id;
        public EditUnit? FrictionDropPressure { get; set; } = new(PressureDropUnits.psi);
        //public int? OverallDropPressureId => OverallDropPressureCommand?.Id==0 ? null : OverallDropPressure?.Id;
        public EditUnit? OverallDropPressure { get; set; } = new(PressureDropUnits.psi);
        //public int? ElevationChangeId => ElevationChangeCommand?.Id==0 ? null : ElevationChange?.Id;
        public EditUnit? ElevationChange { get; set; } = new(PressureDropUnits.psi);


        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

        public List<EditNozzle>? Nozzles { get; set; } = new();

       
    }

}
