using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemProcessConditions
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        [Parameter]
        public AddEditProcessConditionCommand ProcessCondition { get; set; }

        [Parameter]
        public EventCallback<AddEditProcessConditionCommand> ProcessConditionChanged { get; set; }

        [Parameter]
        public AddEditProcessFluidCommand ProcessFluid { get; set; }

        [Inject]
        public IMediator mediator { get; set; }
        [Parameter]
        public EventCallback<AddEditProcessFluidCommand> ProcessFluidChanged { get; set; }

        async Task OnProcessFluidChanged(AddEditProcessFluidCommand pro)
        {
            ProcessFluid = pro;
            await ProcessFluidChanged.InvokeAsync(ProcessFluid);
        }

    }
}
