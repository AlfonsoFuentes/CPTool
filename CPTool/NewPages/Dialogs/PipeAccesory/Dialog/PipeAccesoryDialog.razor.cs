using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Query.GetById;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.PipeAccesory.Dialog
{
    public partial class PipeAccesoryDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPipeAccesory Model { get; set; } = null!;


        EditNozzle SelectedNozzle = new();


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

        private string ValidatePipeDiameter(string arg)
        {
            if (arg == null || arg == "")
                return "Must define pipe diameter";


            if (!GlobalTables.PipeDiameters.Any(x => x.Name == arg))
            {
                return $"Diameter : {arg} is not the list";

            }


            return null;
        }
       
        private string ValidateAccesoryType(PipeAccesorySectionType arg)
        {
            if (arg == PipeAccesorySectionType.None)
                return "Must submit Accesory Type";

            
            return null;
        }
    }
}
