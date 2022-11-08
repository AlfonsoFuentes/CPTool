

using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;

namespace CPTool.Application.Features.ControlLoopFeatures.CreateEdit
{
    public class EditControlLoop : EditCommand, IRequest<Result<int>>
    {

        public ControlLoopType ControlLoopType { get; set; } = ControlLoopType.None;
        public int? ProcessVariableId => ProcessVariable?.Id == 0 ? null : ProcessVariable?.Id;
        EditSignal? _ProcessVariable = new();
        public EditSignal? ProcessVariable
        {
            get
            {
                return _ProcessVariable;
            }

            set
            {
                _ProcessVariable = value;

            }

        }
        public int? ControlledVariableId => ControlledVariable?.Id == 0 ? null : ControlledVariable?.Id;
        public EditSignal? ControlledVariable { get; set; } = new();

        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;
        public EditMWO? MWO { get; set; } = new();

        public int? ProcessVariableMinId => ProcessVariableMin?.Id == 0 ? null : ProcessVariableMin?.Id;
        public EditUnit? ProcessVariableMin { get; set; } = new();
        public int? ProcessVariableMaxId => ProcessVariableMax?.Id == 0 ? null : ProcessVariableMax?.Id;
        public EditUnit? ProcessVariableMax { get; set; } = new();
        public int? SPId => SP?.Id == 0 ? null : SP?.Id;
        public EditUnit? SP { get; set; }

        public int? ProcessVariableValueId => ProcessVariableValue?.Id == 0 ? null : ProcessVariableValue?.Id;
        public EditUnit? ProcessVariableValue { get; set; } = new();

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
