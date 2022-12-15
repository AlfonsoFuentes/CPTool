using CPTool.Domain.Entities;
using CPTool.Persistence.BaseClass;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Templates
{
    public partial class SelectEnumTemplate<T>
        where T : Enum
    {
        [Parameter]
       
        public string PropertyName { get; set; } = string.Empty;
        [Parameter]
        [EditorRequired]
        public T[] Elements { get; set; }
        [Parameter]
        public T Value { get; set; }
        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }

        [Parameter]
        public bool Required { get; set; } = false;
        string enumname => Value.ToString();
        string RequiredText => $"{Label} is required";
        [Parameter]
        [EditorRequired]
        public string Label { get; set; }
        protected override void OnInitialized()
        {
           
            base.OnInitialized();
        }
        [Parameter]
        public bool Disabled { get; set; } = false;
    }
}
