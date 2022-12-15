using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Domain.Enums;
using CPTool.Services;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ControlLoop.Dialog
{
    public partial class ControlLoopDialog : DialogTemplate<EditControlLoop>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
            RadzenTables.Signals = await QuerySignal.GetAll();
        }
       
        public List<EditSignal> signalsIn => GetSignalsIn();
        public List<EditSignal> signalsOut => GetSignalsOut();

        List<EditSignal> GetSignalsIn()
        {
            List<EditSignal> signalsin = RadzenTables.Signals.Where(x =>
                            x.MWOId == Model.MWOId && x.IOType == IOType.In && x.SignalModifier != null && x.SignalModifier?.Name == "Scaled").ToList();

            if (Model.Id == 0 && (Model.ControlLoopType == ControlLoopType.PIDControl || Model.ControlLoopType == ControlLoopType.ON_OFF_Control))
            {
                signalsin = signalsin.Where(x => x.ProcessVariables.Count == 0).ToList();
            }


            return signalsin;

        }
        List<EditSignal> GetSignalsOut()
        {
            List<EditSignal> signalsout = RadzenTables.Signals.Where(x =>
                            x.MWOId == Model.MWOId && x.IOType == IOType.Out
        && x.SignalModifier != null && x.SignalModifier?.Name == "Target").ToList();

            if (Model.Id == 0 && (Model.ControlLoopType == ControlLoopType.PIDControl || Model.ControlLoopType == ControlLoopType.ON_OFF_Control))
            {
                signalsout = signalsout.Where(x => x.ControlledVariables.Count == 0).ToList();
            }



            return signalsout;

        }
    }
}
