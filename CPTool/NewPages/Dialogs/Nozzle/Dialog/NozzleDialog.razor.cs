using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Query.GetById;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.Nozzle.Dialog
{
    public partial class NozzleDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public AddEditNozzleCommand Model { get; set; } = null!;



        [Inject]
        public IMediator mediator { get; set; }

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

                await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

        private string ValidateNozzleName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Nozzle name";
            if (Model.ParentNozzles.Where(x => x.Id != Model.Id).Any(x => x.Name == arg))
            {
                return $"Nozzle name: {arg} is in the list";

            }


            return null;
        }
      
        private string ValidateNozzleType(StreamType arg)
        {
            if (arg == StreamType.None)
                return "Must submit In/Out Type";


            return null;
        }
        async Task PipeClassChanged(AddEditPipeClassCommand arg)
        {
            if(arg.Id!=0)
            {
                GetByIdPipeClassQuery getclass = new() { Id = arg.Id, };
                Model.PipeClassCommand = await mediator.Send(getclass);
                Model.PipeDiameterCommand = new();
              
            }
            else
            {
                Model.PipeClassCommand = new();
                Model.PipeDiameterCommand = new();
            }
            StateHasChanged();
        }
    }
}
