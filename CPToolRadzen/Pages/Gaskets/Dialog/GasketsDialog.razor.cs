using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.Gaskets.Dialog
{
    public partial class GasketsDialog : DialogTemplate<EditGasket>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.Gaskets : RadzenTables.Gaskets.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
