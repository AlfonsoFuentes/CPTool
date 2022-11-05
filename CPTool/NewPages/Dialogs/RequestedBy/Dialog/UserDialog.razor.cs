

namespace CPTool.NewPages.Dialogs.RequestedBy.Dialog
{
    public partial class UserDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditUser Model { get; set; } = null!;



        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
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

        private string ValidateRequestedByName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Process fluid name";

            if(Model.Id==0)
            {
                if(GlobalTables.Users.Any(x=>x.Name==arg))
                {
                    return "Name Existing";
                }
            }
            else
            {
                if (GlobalTables.Users.Where(x=>x.Id!= Model.Id).Any(x => x.Name == arg))
                {
                    return "Name Existing";
                }
            }


            return null;
        }
    }
}
