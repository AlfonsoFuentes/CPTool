namespace CPTool.Domain.Entities
{
    public class ControlLoop : BaseDomainModel
    {

        public int? MWOId { get; set; }
        public MWO? MWO { get; set; }
        public ControlLoopType ControlLoopType { get; set; }
        public int? ProcessVariableId { get; set; }
        public Signal? ProcessVariable { get; set; }
        public int? ControlledVariableId { get; set; }
        public Signal? ControlledVariable { get; set; }

        public double PTerm { get; set; }
        public double ITerm { get; set; }
        public double DTerm { get; set; }


        public int? ProcessVariableMinId { get; set; }
        public Unit? ProcessVariableMin { get; set; }
        public int? ProcessVariableMaxId { get; set; }
        public Unit? ProcessVariableMax { get; set; }


        public int? ProcessVariableValueId { get; set; }
        public Unit? ProcessVariableValue { get; set; }

        public double ControlledVariableMin { get; set; }
        public double ControlledVariableMax { get; set; }
        public double ControlledVariableValue { get; set; }
        public int? SPId { get; set; }
        public Unit? SP { get; set; }

        public double PVRange { get; set; }
        public double WindupGuard { get; set; }
        public bool ManualOverride { get; set; }
        public bool DirectActing { get; set; }
        public bool FailClose { get; set; }

        public string TagNumber { get; set; } = string.Empty;
        public string AlarmText { get; set; } = string.Empty;
    }
}
