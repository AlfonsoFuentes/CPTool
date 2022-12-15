

using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.Domain.Enums;
using CPTool.UnitsSystem;

namespace CPTool.Application.Features.ControlLoopFeatures.CreateEdit
{
    public class EditControlLoop : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string ControlLoopTypeName => ControlLoopType.ToString();
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
        [Report(Order = 4)]
        public string ProcessVariableName => ProcessVariable == null ?"": ProcessVariable!.Name;
        public int? ControlledVariableId => ControlledVariable?.Id == 0 ? null : ControlledVariable?.Id;
        [Report(Order = 5)]
        public string ControlledVariableName => ControlledVariable == null ? "" : ControlledVariable!.Name;
        public EditSignal? ControlledVariable { get; set; } = new();

        public int? MWOId => MWO?.Id == 0 ? null : MWO?.Id;
        [Report(Order = 6)]
        public string MWOName => MWO == null ? "" : MWO!.Name;
        public EditMWO? MWO { get; set; } = new();

        public int? ProcessVariableMinId => ProcessVariableMin?.Id == 0 ? null : ProcessVariableMin?.Id;
        [Report(Order = 7)]
        public string ProcessVariableMinName => ProcessVariableMin == null ? "" : ProcessVariableMin!.Name;
        public EditUnit? ProcessVariableMin { get; set; } = new();
        public int? ProcessVariableMaxId => ProcessVariableMax?.Id == 0 ? null : ProcessVariableMax?.Id;
        [Report(Order = 8)]
        public string ProcessVariableMaxName => ProcessVariableMax == null ? "" : ProcessVariableMax!.Name;
        public EditUnit? ProcessVariableMax { get; set; } = new();
        public int? SPId => SP?.Id == 0 ? null : SP?.Id;
        [Report(Order = 9)]
        public string SPName => SP == null ? "" : SP!.Name;

        public EditUnit? SP { get; set; } = new();

        public int? ProcessVariableValueId => ProcessVariableValue?.Id == 0 ? null : ProcessVariableValue?.Id;
        [Report(Order = 10)]
        public string ProcessVariableValueName => ProcessVariableValue == null ? "" : ProcessVariableValue!.Name;
        public EditUnit? ProcessVariableValue { get; set; } = new();
        [Report(Order = 11)]
        public double PTerm { get; set; }
        [Report(Order = 12)]
        public double ITerm { get; set; }
        [Report(Order = 13)]
        public double DTerm { get; set; }
        [Report(Order = 14)]
        public double ControlledVariableMin { get; set; }
        [Report(Order = 15)]
        public double ControlledVariableMax { get; set; }
        [Report(Order = 16)]
        public double ControlledVariableValue { get; set; }

        [Report(Order = 17)]
        public double PVRange { get; set; }
        [Report(Order = 18)]
        public double WindupGuard { get; set; }
        [Report(Order = 19)]
        public bool ManualOverride { get; set; }
        [Report(Order = 20)]
        public string ActionTypeName => ActionType.ToString();
        public ActionType ActionType { get; set; }
        [Report(Order = 21)]
        public string FailTypeName => FailType.ToString();
        public FailType FailType { get; set; }

        [Report(Order = 22)]
        public string TagNumber { get; set; } = string.Empty;
        [Report(Order = 23)]
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



