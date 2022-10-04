
using CPTool.Application.Features.MWOFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWO.List
{
    public partial class MWOList
    {

        AddEditMWOCommand SelectedMaster { get; set; } = new();
        AddEditMWOItemCommand SelectedDetail { get; set; } = new();
        [Parameter]
        public RenderFragment OtherButtons { get; set; }

      
        
    }
}
