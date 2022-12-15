using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.ControlLoop.Dialog
{
    public partial class ControlLoopPIDDialog
    {
        [CascadingParameter]
        protected ControlLoopDialog DialogParent { get; set; }
        public EditControlLoop Model => DialogParent.Model;
    }
}
