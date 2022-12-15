
using CPTool.Application.Features.UserRequirementTypeFeatures.CreateEdit;


namespace CPToolRadzen.Pages.UserRequirementType.Dialog
{
    public partial class UserRequirementTypeDialog : DialogTemplate<EditUserRequirementType>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
