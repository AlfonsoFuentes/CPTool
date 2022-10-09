using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.Command.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.Command.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemMaterialsComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        [Parameter]

        public AddEditGasketCommand Gasket { get; set; }
        [Parameter]
        public EventCallback<AddEditGasketCommand> GasketChanged { get; set; }
        [Parameter]
        public AddEditMaterialCommand InnerMaterial { get; set; }
        [Parameter]
        public EventCallback<AddEditMaterialCommand> InnerMaterialChanged { get; set; }
        [Parameter]

        public AddEditMaterialCommand OuterMaterial { get; set; }
        [Parameter]
        public EventCallback<AddEditMaterialCommand> OuterMaterialChanged { get; set; }

        async Task OnGasketChanged(AddEditGasketCommand gas)
        {
            Gasket = gas;
            await GasketChanged.InvokeAsync(Gasket);
        }
        async Task OnInnerMaterialChanged(AddEditMaterialCommand mat)
        {
            InnerMaterial = mat;
            await InnerMaterialChanged.InvokeAsync(InnerMaterial);
        }
        async Task OnOuterMaterialChanged(AddEditMaterialCommand mat)
        {
            OuterMaterial = mat;
            await OuterMaterialChanged.InvokeAsync(OuterMaterial);
        }
    }
}
