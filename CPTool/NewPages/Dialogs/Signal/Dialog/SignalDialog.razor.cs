using CPTool.Application.Features.SignalsFeatures.CreateEdit;
using CPTool.Domain.Enums;

namespace CPTool.NewPages.Dialogs.Signal.Dialog
{
    public partial class SignalDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditSignal Model { get; set; } = null!;

        List<EditMWOItem> MWOItems  => GetMWOItems();
       
        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        List<EditMWOItem> GetMWOItems()
        {
            var result = GlobalTables.MWOItems.Where(x => x.MWOId == Model.MWOId && x.TagId != "" && x.ChapterId != 6).ToList();
            return result;

        }
        async Task Validateform()
        {
            await form.Validate();
        }
        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {

                await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

        private string ValidateIOType(IOType arg)
        {
            if (arg == IOType.None)
                return "Must submit In/Out Type";


            return null;
        }
    }
}
