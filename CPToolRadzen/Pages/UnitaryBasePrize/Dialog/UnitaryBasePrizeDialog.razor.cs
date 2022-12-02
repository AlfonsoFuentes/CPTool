
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;


namespace CPToolRadzen.Pages.UnitaryBasePrize.Dialog
{
    public partial class UnitaryBasePrizeDialog : DialogTemplate<EditUnitaryBasePrize>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.UnitaryBasePrizes : RadzenTables.UnitaryBasePrizes.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
