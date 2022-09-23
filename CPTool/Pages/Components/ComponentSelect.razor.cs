using Microsoft.AspNetCore.Components;

namespace CPTool.Pages.Components
{
    public partial class ComponentSelect<TDTO>
        where TDTO : AuditableEntityDTO, new()
        
    {
        [Parameter]
        public TDTO Model { get; set; }
        [Parameter]
        public bool Disable { get; set; } = false;
      
        public int ModelInt { get; set; } = 0;
       

        [Parameter]
        public EventCallback<TDTO> ModelChanged { get; set; }
       
        [Parameter]
        public string RequiredError { get; set; }
        [Parameter]
        public bool Required { get; set; }
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        [Category(CategoryTypes.FormComponent.Validation)]
        public object Validation { get; set; }

        [Parameter]
        [EditorRequired]
        public List<TDTO> Elements { get; set; } = new();
        [Parameter]
        public Action PostEvent { get; set; }
        [Parameter]
        public Func<Task> PostEventAsync { get; set; }
        protected override void OnInitialized()
        {   
           
            ModelInt = Model.Id;
            base.OnInitialized();
        }
        async Task ValueChanged(int value)
        {
            ModelInt = value;
           
            Model = Elements.FirstOrDefault(x => x.Id == value);
            await ModelChanged.InvokeAsync(Model);

            if (PostEvent != null) PostEvent.Invoke();
            if (PostEventAsync != null) await PostEventAsync.Invoke();
        }
    }
}
