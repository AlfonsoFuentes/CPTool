
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Templates
{
    public partial class SelectTemplate<T> where T : class,new()
    {
        [Parameter]
        [EditorRequired]
        public string PropertyName { get; set; } = string.Empty;
        string classname => typeof(T).Name;
        [Parameter]
        public List<T> Elements { get; set; }

        T _Model;
        [Parameter]
        public T Model { get { return _Model; } set{ _Model = value; } }

      
       
        [Parameter]
        public EventCallback<T> ModelChanged { get; set; }

      
        [Parameter]
        public bool Disabled { get; set; } = false;
        [Parameter]
        public bool Clearable { get; set; } = false;

        string RequiredText => $"{Label} is required";
        [Parameter]
        [EditorRequired]
        public string Label { get; set; }
       
        async Task OnChange()
        {
            Model = _Model == null ? new() : _Model;
            await ModelChanged.InvokeAsync(Model);
            if (Change.HasDelegate) await Change.InvokeAsync();

        }
        [Parameter]
        public EventCallback Change { get; set; }

        public void Reset()
        {
            RadzenDropDown.Reset();
        }
      
    }
}
