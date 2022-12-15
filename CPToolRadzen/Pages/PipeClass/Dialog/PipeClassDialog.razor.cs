using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.PipeClassFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.PipeClass.Dialog
{
    public partial class PipeClassDialog : DialogTemplate<EditPipeClass>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
