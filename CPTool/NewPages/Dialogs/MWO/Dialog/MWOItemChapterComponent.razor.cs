using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWO.Dialog
{
    public partial class MWOItemChapterComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected AddEditMWOItemCommand Model => DialogParent.Model;
        
    }
}
