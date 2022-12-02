using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPToolRadzen.Templates;

namespace CPToolRadzen.Pages.ProcessFluid.Dialog
{
    public partial class ProcessFluidDialog : DialogTemplate<EditProcessFluid>
    {
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.ProcessFluids : RadzenTables.ProcessFluids.Where(x => x.Id != Model.Id).ToList();
        }
    }
}
