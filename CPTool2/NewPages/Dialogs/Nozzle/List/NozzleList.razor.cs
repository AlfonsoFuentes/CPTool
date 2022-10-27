using CPTool.Application.Features.NozzleFeatures.CreateEdit;

namespace CPTool2.NewPages.Dialogs.Nozzle.List
{
    public partial class NozzleList
    {
        [Parameter]
        public List<EditNozzle> Nozzles { get; set; } = new();

        [Parameter]
       
        public EventCallback<List<EditNozzle>> NozzlesChanged { get; set; }
        [Parameter]
        [EditorRequired]
        public EditCommand Master { get; set; }

        [Parameter]
        [EditorRequired]
        public EventCallback UpdateParentList { get; set; }

        EditNozzle SelectedNozzle { get; set; } = new();

        

    }
}
