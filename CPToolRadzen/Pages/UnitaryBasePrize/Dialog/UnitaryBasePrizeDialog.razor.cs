
using CPTool.Application.Features.UnitaryBasePrizeFeatures.CreateEdit;


namespace CPToolRadzen.Pages.UnitaryBasePrize.Dialog
{
    public partial class UnitaryBasePrizeDialog : DialogTemplate<EditUnitaryBasePrize>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
