using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemProcessConditions
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        [Parameter]
        public EditProcessCondition ProcessCondition { get; set; }

        [Parameter]
        public EventCallback<EditProcessCondition> ProcessConditionChanged { get; set; }

        [Parameter]
        public EditProcessFluid ProcessFluid { get; set; }

        [Inject]
        public IMediator mediator { get; set; }
        [Parameter]
        public EventCallback<EditProcessFluid> ProcessFluidChanged { get; set; }

        async Task OnProcessFluidChanged(EditProcessFluid pro)
        {
            ProcessFluid = pro;
            await ProcessFluidChanged.InvokeAsync(ProcessFluid);
        }

    }
}
