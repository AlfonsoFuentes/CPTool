using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.Taks.Dialog
{
    public partial class TaksDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditTaks Model { get; set; } = null!;



        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
        }
        bool ButtonSaveDisable => Model.TaksType == Domain.Entities.TaksType.Automatic ? true :
            Model.TaksStatus == Domain.Entities.TaksStatus.Completed ? true : false;
        string ButtonSaveName => Model.TaksType == Domain.Entities.TaksType.Manual ?
            Model.TaksStatus == Domain.Entities.TaksStatus.Draft ? "Create" : "Close" : "Automatic";
        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {
                if (Model.TaksType == Domain.Entities.TaksType.Manual)
                {
                    if (Model.TaksStatus == Domain.Entities.TaksStatus.Draft)
                    {
                        Model.TaksStatus = Domain.Entities.TaksStatus.Pending;

                    }
                    else if (Model.TaksStatus == Domain.Entities.TaksStatus.Pending)
                    {
                        Model.TaksStatus = Domain.Entities.TaksStatus.Completed;
                        Model.CompletionDate = DateTime.Now;
                    }
                }

                await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
        private string ValidateTaskName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Task name";



            return null;
        }
    }
}
