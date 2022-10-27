using CPTool.Application.Features.GasketsFeatures.CreateEdit;
using CPTool.Application.Features.MaterialFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Domain.Entities;
using CPTool2.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;
namespace CPTool2.NewPages.Dialogs.MWOItem.Dialog
{
    public partial class MWOItemMaterialsComponent
    {
        [CascadingParameter]
        protected MWOItemDialog DialogParent { get; set; }
        [Parameter]

        public EditGasket Gasket { get; set; }
        [Parameter]
        public EventCallback<EditGasket> GasketChanged { get; set; }
        [Parameter]
        public EditMaterial InnerMaterial { get; set; }
        [Parameter]
        public EventCallback<EditMaterial> InnerMaterialChanged { get; set; }
        [Parameter]

        public EditMaterial OuterMaterial { get; set; }
        [Parameter]
        public EventCallback<EditMaterial> OuterMaterialChanged { get; set; }

        async Task OnGasketChanged(EditGasket gas)
        {
            Gasket = gas;
            await GasketChanged.InvokeAsync(Gasket);
        }
        async Task OnInnerMaterialChanged(EditMaterial mat)
        {
            InnerMaterial = mat;
            await InnerMaterialChanged.InvokeAsync(InnerMaterial);
        }
        async Task OnOuterMaterialChanged(EditMaterial mat)
        {
            OuterMaterial = mat;
            await OuterMaterialChanged.InvokeAsync(OuterMaterial);
        }
    }
}
