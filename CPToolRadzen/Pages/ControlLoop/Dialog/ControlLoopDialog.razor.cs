using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ControlLoop.Dialog
{
    public partial class ControlLoopDialog : DialogTemplate<EditControlLoop>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.ControlLoops : RadzenTables.ControlLoops.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
