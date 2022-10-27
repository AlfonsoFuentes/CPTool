using CPTool.Application.Features.UnitFeatures.CreateEdit;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using CPTool.Application.Features.Base;
using MediatR;

using CPTool.Application.Features.Base.DeleteCommand;
namespace CPTool2.NewPages.Components
{
    public partial class SelectUnitComponent
    {
        [Parameter]
        public EditUnit Model { get; set; }
        [Parameter]
        public EventCallback<EditUnit> ModelChanged { get; set; }
        [Parameter]
        public bool Disable { get; set; }
        async Task UnitChanged(string name)
        {
            Model.UnitName = name;
            await ModelChanged.InvokeAsync(Model);
            await UpdateParent.Invoke();
        }
        async Task OnValueChanged(string value)
        {
           
            await ModelChanged.InvokeAsync(Model);
            await UpdateParent.Invoke();
        }
        [Parameter]
        [EditorRequired]
        public Func<Task> UpdateParent { get; set; }
    }
}
