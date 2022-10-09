using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;

namespace CPTool.NewPages.Dialogs.Nozzle.List
{
    public partial class NozzleList
    {
        [Parameter]
      
        public List<AddEditNozzleCommand> Nozzles { get; set; } = new();

        [Parameter]
       
        public EventCallback<List<AddEditNozzleCommand>> NozzlesChanged { get; set; }
        [Parameter]
        [EditorRequired]
        public AddEditCommand Master { get; set; }

        [Parameter]
        [EditorRequired]
        public EventCallback UpdateParent { get; set; }

        AddEditNozzleCommand SelectedNozzle { get; set; }

    }
}
