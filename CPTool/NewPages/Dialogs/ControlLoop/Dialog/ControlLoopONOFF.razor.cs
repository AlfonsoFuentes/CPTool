using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.ControlLoop.Dialog
{
    public partial class ControlLoopONOFF
    {
        [CascadingParameter]
        protected ControlLoopDialog DialogParent { get; set; }
        public EditControlLoop Model => DialogParent.Model;
    }
}
