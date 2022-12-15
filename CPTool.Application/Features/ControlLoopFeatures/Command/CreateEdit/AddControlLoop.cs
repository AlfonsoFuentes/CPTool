

using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.Domain.Enums;

namespace CPTool.Application.Features.ControlLoopFeatures.CreateEdit
{
    public class AddControlLoop : AddCommand
    {
        public AddUnit? ProcessVariableMin { get; set; }
        public AddUnit? SP { get; set; }
        public AddUnit? ProcessVariableMax { get; set; }
        public AddUnit? ProcessVariableValue { get; set; }
        public ControlLoopType ControlLoopType { get; set; }
        public int? ProcessVariableId { get; set; }
        public int? ControlledVariableId { get; set; }

        public int? MWOId { get; set; }
      
        public double PTerm { get; set; }
        public double ITerm { get; set; }
        public double DTerm { get; set; }
        public double ControlledVariableMin { get; set; }
        public double ControlledVariableMax { get; set; }
        public double ControlledVariableValue { get; set; }


        public double PVRange { get; set; }
        public double WindupGuard { get; set; }
        public bool ManualOverride { get; set; }
        public ActionType ActionType { get; set; }
        public FailType FailType { get; set; }


        public string TagNumber { get; set; } = string.Empty;
        public string AlarmText { get; set; } = string.Empty;

    }
}
