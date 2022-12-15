using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ProcessFluid.Dialog
{
    public partial class ProcessFluidDialog : DialogTemplate<EditProcessFluid>
    {
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
            RadzenTables.PropertyPackages=await QueryPropertyPackage.GetAll();
        }
    }
}
