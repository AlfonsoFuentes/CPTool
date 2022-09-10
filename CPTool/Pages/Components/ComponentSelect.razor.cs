using Microsoft.AspNetCore.Components;

namespace CPTool.Pages.Components
{
    public partial class ComponentSelect<TDTO, T>
        where TDTO : AuditableEntityDTO, new()
        where T : AuditableEntity, new()
    {
        [Parameter]
        public TDTO Model { get; set; } = new();
        [Parameter]
        public bool Disable { get; set; } = false;
        [Parameter]
        public int ModelInt { get; set; } = 0;
        [Parameter]
        public EventCallback<int> ModelIntChanged { get; set; }

        [Parameter]
        public EventCallback<TDTO> ModelChanged { get; set; }
        [Parameter]
        public string TableName { get; set; }
        [Parameter]
        public string RequiredError { get; set; }
        [Parameter]
        public bool Required { get; set; }
        [Parameter]
        public string Label { get; set; }
       
        [Parameter]
        [EditorRequired]
        public List<TDTO> Elements { get; set; } = new();
        [Parameter]
        public Action PostEvent { get; set; }
       
        protected override void OnInitialized()
        {

            base.OnInitialized();
        }
        async Task ValueChanged(int value)
        {
            ModelInt = value;
            await ModelIntChanged.InvokeAsync(ModelInt);
            Model = Elements.FirstOrDefault(x => x.Id == value);
            await ModelChanged.InvokeAsync(Model);
         
            if (PostEvent != null) PostEvent.Invoke();
        }
    }
}
