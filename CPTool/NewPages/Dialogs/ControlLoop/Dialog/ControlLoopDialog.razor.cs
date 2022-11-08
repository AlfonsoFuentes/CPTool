

using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.ControlLoop.Dialog
{
    public partial class ControlLoopDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditControlLoop Model { get; set; } = null!;

        List<EditSignal> signalsIn => GlobalTables.Signals.Where(x => x.MWOId == Model.MWOId && x.IOType == IOType.In).ToList();
        List<EditSignal> signalsOut => GlobalTables.Signals.Where(x => x.MWOId == Model.MWOId && x.IOType == IOType.Out).ToList();
        [Parameter]
        public MudForm form { get; set; } = null!;


        public async virtual Task Submit()
        {
            await form.Validate();
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
