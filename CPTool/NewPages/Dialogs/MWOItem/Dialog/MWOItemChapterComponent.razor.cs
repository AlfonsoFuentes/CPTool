using CPTool.Application.Features.ChapterFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemChapterComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        protected EditMWOItem Model => DialogParent.Model;

       

    }
}
