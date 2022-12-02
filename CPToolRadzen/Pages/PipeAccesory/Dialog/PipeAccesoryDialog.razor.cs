using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.PipeAccesory.Dialog
{
    public partial class PipeAccesoryDialog : DialogTemplate<EditPipeAccesory>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.PipeAccesorys : RadzenTables.PipeAccesorys.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
