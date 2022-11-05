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

        private string ValidateNozzleName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Nozzle name";



            return null;
        }
        private string ValidatePipeDiameter(string arg)
        {
            if (arg == null || arg == "")
                return "Must define pipe diameter";


            if (!Model.nPipeClass.PipeDiameters.Any(x => x.Name == arg))
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
        async void PipeClassChanged(EditPipeClass arg)
        {
            if (arg.Id != 0)
            {
                GetByIdPipeClassQuery query = new() { Id = arg.Id };

                Model.nPipeClass = await Mediator.Send(query);
                Model.PipeDiameter = new();

            }
            else
            {
                Model.nPipeClass = new();
                Model.PipeDiameter = new();
            }
            StateHasChanged();
        }
        async Task UpdatePipeClassFromPipeDiameter()
        {
            GetPipeClassListQuery pipeclaslist = new();

            GlobalTables.PipeClasses = await Mediator.Send(pipeclaslist);
            PipeClassChanged(Model.nPipeClass);
            StateHasChanged();
        }
    }
}
