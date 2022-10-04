namespace CPTool.NewPages.Components
{
    public partial class SelectComponent<T> where T : AddEditCommand
    {

        [Parameter]
        public bool Disable { get; set; } = false;
        [Parameter]
        [EditorRequired]
        public T Value { get; set; }

        int ValueInt => Value.Id;
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
        public List<T> Elements { get; set; } = new();

        [Parameter]
       
        public EventCallback<T> SelectionChanged { get; set; }

        async Task InternaSelectChanged(int id)
        {
            Value = Elements.FirstOrDefault(x => x.Id == id);
            await SelectionChanged.InvokeAsync(Value);
        }
        

    }
}