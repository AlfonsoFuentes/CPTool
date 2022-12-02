

using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.UnitsSystem;

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
                CreateAmount();
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
        public EditUnit? SP { get; set; } = new();

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
        public ActionType ActionType { get; set; }
        public FailType FailType { get; set; }


        public string TagNumber { get; set; } = string.Empty;
        public string AlarmText { get; set; } = string.Empty;


        void CreateAmount()
        {
            if (ProcessVariable?.MWOItem?.ChapterId == 7 && ProcessVariable?.MWOItem?.InstrumentItem != null)
            {
                var instrument = ProcessVariable?.MWOItem.InstrumentItem;
               
                switch (instrument?.MeasuredVariable?.TagLetter)
                {
                    case "F":
                        {
                            SP = new(MassFlowUnits.Kg_hr);
                            ProcessVariableValue = new(MassFlowUnits.Kg_hr);
                            ProcessVariableMax = new(MassFlowUnits.Kg_hr);
                            ProcessVariableMin = new(MassFlowUnits.Kg_hr);
                        }
                        break;
                    case "L":
                        {
                            SP = new(PercentageUnits.Percentage);
                            ProcessVariableValue = new(PercentageUnits.Percentage);
                            ProcessVariableMax = new(PercentageUnits.Percentage);
                            ProcessVariableMin = new(PercentageUnits.Percentage);
                        }
                        break;
                    case "P":
                        {
                            SP = new(PressureUnits.Bar);
                            ProcessVariableValue = new(PressureUnits.Bar);
                            ProcessVariableMax = new(PressureUnits.Bar);
                            ProcessVariableMin = new(PressureUnits.Bar);
                        }
                        break;
                    //case "S":
                    //    {
                    //        ProcessVariableValue = new.Bar);
                    //    }
                    //    break;

                    case "T":
                        {
                            SP = new(TemperatureUnits.DegreeCelcius);
                            ProcessVariableValue = new(TemperatureUnits.DegreeCelcius);
                            ProcessVariableMax = new(TemperatureUnits.DegreeCelcius);
                            ProcessVariableMin = new(TemperatureUnits.DegreeCelcius);
                        }
                        break;
                    case "W":
                        {
                            SP = new(MassUnits.KiloGram);
                            ProcessVariableValue = new(MassUnits.KiloGram);
                            ProcessVariableMax = new(MassUnits.KiloGram);
                            ProcessVariableMin = new(MassUnits.KiloGram);
                        }
                        break;


                }
                ProcessVariableValue!.Name = ProcessVariable!.Name;
                SP!.Name = $"{instrument!.TagId}.SP";
                ProcessVariableMax!.Name = $"{instrument!.TagId}.Max";
                ProcessVariableMin!.Name = $"{instrument!.TagId}.Min";
            }
        }

    }
}



