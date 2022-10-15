using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.Query.GetById;
using CPTool.Application.Features.PipeClassFeatures.Query.GetList;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.Nozzle.Dialog
{
    public partial class NozzleDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditNozzle Model { get; set; } = null!;



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
            if (Model.ParentNozzles.Where(x => x.Id !=Model.Id).Any(x => x.Name == arg))
            {
                return $"Nozzle name: {arg} is in the list";

            }


            return null;
        }
        private string ValidatePipeDiameter(string arg)
        {
            if (arg == null || arg == "")
                return "Must define pipe diameter";

          
            if (!Model.PipeClass.PipeDiameters.Any(x => x.Name == arg))
            {
                return $"Diameter : {arg} is not the list";

            }


            return null;
        }
        private string ValidateNozzleType(StreamType arg)
        {
            if (arg == StreamType.None)
                return "Must submit In/Out Type";


            return null;
        }
        async Task PipeClassChanged(EditPipeClass arg)
        {
            if (arg.Id != 0)
            {
                GetByIdPipeClassQuery getclass = new() { Id=arg.Id }; 
                Model.PipeClass = await mediator.Send(getclass);
                Model.PipeDiameter = new();

            }
            else
            {
                Model.PipeClass = new();
                Model.PipeDiameter = new();
            }
            StateHasChanged();
        }
        async Task UpdatePipeClassFromPipeDiameter()
        {
            GetPipeClassListQuery pipeclaslist = new();

            GlobalTables.PipeClasses = await mediator.Send(pipeclaslist);
            await PipeClassChanged(Model.PipeClass);
            StateHasChanged();
        }
    }
}
