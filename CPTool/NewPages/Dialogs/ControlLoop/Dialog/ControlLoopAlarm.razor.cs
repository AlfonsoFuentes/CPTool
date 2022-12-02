using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.ControlLoop.Dialog
{
    public partial class ControlLoopAlarm
    {

        [CascadingParameter]
        protected ControlLoopDialog DialogParent { get; set; }
        public EditControlLoop Model => DialogParent.Model;
    }
}
