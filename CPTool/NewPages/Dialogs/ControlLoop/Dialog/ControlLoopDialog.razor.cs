

using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.ControlLoop.Dialog
{
    public partial class ControlLoopDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditControlLoop Model { get; set; } = null!;

        public List<EditSignal> signalsIn => GetSignalsIn();
        public List<EditSignal> signalsOut => GetSignalsOut();
        public MudForm form { get; set; } = null!;
        List<EditSignal> GetSignalsIn()
        {
            List<EditSignal> signalsin = GlobalTables.Signals.Where(x =>
                            x.MWOId == Model.MWOId && x.IOType == IOType.In && x.SignalModifier != null && x.SignalModifier?.Name == "Scaled").ToList();

            if (Model.Id == 0 && Model.ControlLoopType == ControlLoopType.PIDControl || Model.ControlLoopType == ControlLoopType.ON_OFF_Control)
            {
                signalsin = signalsin.Where(x => x.ProcessVariables.Count == 0).ToList();
            }


            return signalsin;

        }
        List<EditSignal> GetSignalsOut()
        {
            List<EditSignal> signalsout = GlobalTables.Signals.Where(x =>
                            x.MWOId == Model.MWOId && x.IOType == IOType.Out
        && x.SignalModifier != null && x.SignalModifier?.Name == "Target").ToList();

            if (Model.Id == 0 && Model.ControlLoopType == ControlLoopType.PIDControl || Model.ControlLoopType == ControlLoopType.ON_OFF_Control)
            {
                signalsout = signalsout.Where(x => x.ControlledVariables.Count == 0).ToList();
            }

          

            return signalsout;

        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        public async Task Validateform()
        {
            await form.Validate();
        }
        public async virtual Task Submit()
        {
            await Validateform();
            if (form.IsValid)
            {

                var result = await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
        private string ValidateControlLoopType(ControlLoopType arg)
        {
            if (arg == ControlLoopType.None)
                return "Must submit Control Loop Type";


            return null;
        }
    }
}
