
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.MWOItems.Dialog
{
    public partial class MWOItemDialog : DialogTemplate<EditMWOItem>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.MWOItems : RadzenTables.MWOItems.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
