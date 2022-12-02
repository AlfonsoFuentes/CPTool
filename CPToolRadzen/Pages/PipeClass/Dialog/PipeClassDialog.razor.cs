using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.PipeClass.Dialog
{
    public partial class PipeClassDialog : DialogTemplate<EditPipeClass>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.PipeClasses : RadzenTables.PipeClasses.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
