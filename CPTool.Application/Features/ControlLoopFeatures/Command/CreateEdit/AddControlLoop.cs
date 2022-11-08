

namespace CPTool.Application.Features.ControlLoopFeatures.CreateEdit
{
    public class AddControlLoop : AddCommand
    {

        public ControlLoopType ControlLoopType { get; set; }
        public int? ProcessVariableId { get; set; }
        public int? ControlledVariableId { get; set; }
        public int? ProcessVariableMinId { get; set; }
        public int? ProcessVariableMaxId { get; set; }
        public int? SPId { get; set; }
        public int? MWOId { get; set; }
        public int? ProcessVariableValueId { get; set; }
        public double PTerm { get; set; }
        public double ITerm { get; set; }
        public double DTerm { get; set; }
        public double ControlledVariableMin { get; set; }
        public double ControlledVariableMax { get; set; }
        public double ControlledVariableValue { get; set; }


        public double PVRange { get; set; }
        public double WindupGuard { get; set; }
        public bool ManualOverride { get; set; }
        public bool DirectActing { get; set; }
        public bool FailClose { get; set; }

        public string TagNumber { get; set; } = string.Empty;
        public string AlarmText { get; set; } = string.Empty;

    }
}
