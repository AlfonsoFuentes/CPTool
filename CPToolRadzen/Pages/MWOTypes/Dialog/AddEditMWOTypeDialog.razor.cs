
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;


namespace CPToolRadzen.Pages.MWOTypes.Dialog
{
    public partial class AddEditMWOTypeDialog:DialogTemplate<EditMWOType>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }

    }
}
