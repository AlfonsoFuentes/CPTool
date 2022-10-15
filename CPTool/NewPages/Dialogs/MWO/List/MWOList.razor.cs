
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWO.List
{
    public partial class MWOList
    {

        EditMWO SelectedMaster { get; set; } = new();
        EditMWOItem SelectedDetail { get; set; } = new();
        [Parameter]
        public RenderFragment OtherButtons { get; set; }

      
        
    }
}
