
namespace CPTool.NewPages.Dialogs.UserRequirement.Dialog
{
    public partial class UserRequirementDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditUserRequirement Model { get; set; } = null!;



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

        private string ValidateUserRequirementName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit User Requirement name";

            if (Model.Id == 0)
            {
                if (GlobalTables.UserRequirements.Any(x => x.Name == arg))
                {
                    return "Name Existing";
                }
            }
            else
            {
                if (GlobalTables.UserRequirements.Where(x => x.Id != Model.Id).Any(x => x.Name == arg))
                {
                    return "Name Existing";
                }
            }


            return null;
        }
       
        private string ValidateRequestedBy(string arg)
        {
            if (arg == null || arg == "")
                return "Must Requested by";

            if (Model.RequestedBy.Id == 0)
            {
                if (GlobalTables.Users.Any(x => x.Name == arg))
                    return "Name already exist";
            }
            else
            {
                if (GlobalTables.Users.Where(x => x.Id != Model.RequestedBy.Id).Any(x => x.Name == arg))
                    return "Name already exist";
            }



            return null;
        }
    }
}