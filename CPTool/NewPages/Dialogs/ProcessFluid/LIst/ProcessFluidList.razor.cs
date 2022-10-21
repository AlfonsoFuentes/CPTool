using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.ProcessFluid.List
{
    public partial class ProcessFluidList
    {
        [Parameter]
        public List<EditProcessFluid> ProcessFluids { get; set; } = new();

        [Parameter]
       
        public EventCallback<List<EditProcessFluid>> ProcessFluidsChanged { get; set; }


        EditProcessFluid SelectedProcessFluid { get; set; } = new();

        

    }
}
