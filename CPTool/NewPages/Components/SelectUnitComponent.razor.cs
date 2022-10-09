using CPTool.Application.Features.UnitFeatures.Command.CreateEdit;

namespace CPTool.NewPages.Components
{
    public partial class SelectUnitComponent
    {
        [Parameter]
        public AddEditUnitCommand Model { get; set; }
        [Parameter]
        public EventCallback<AddEditUnitCommand> ModelChanged { get; set; }
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
