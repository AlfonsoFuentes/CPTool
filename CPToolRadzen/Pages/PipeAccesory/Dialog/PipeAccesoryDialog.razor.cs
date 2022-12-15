using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeAccesoryFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.PipeAccesory.Dialog
{
    public partial class PipeAccesoryDialog : DialogTemplate<EditPipeAccesory>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
