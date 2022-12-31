using CPTool.Domain.Enums;

namespace CPTool.Domain.Entities
{
    public class ControlLoop : AuditableEntity
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
        public EntityUnit? ProcessVariableMin { get; set; }
        public int? ProcessVariableMaxId { get; set; }
        public EntityUnit? ProcessVariableMax { get; set; }
        public int? SPId { get; set; }
        public EntityUnit? SP { get; set; }

        public int? ProcessVariableValueId { get; set; }
        public EntityUnit? ProcessVariableValue { get; set; }

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
    public enum FailType
    {
        None,
        Open,
        Close
    }
    public enum ActionType
    {
        None,
        Direct,
        Reverse
    }
}
