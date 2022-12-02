using CPTool.Persistence.BaseClass;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Templates
{
    public partial class NumericTemplate<TValue> 
    {
       
        [Parameter]
        public bool Required { get; set; } = false;
        [Parameter]
        public string Format { get; set; } = "G6";

        string RequiredText => $"{Label} is required";
        [Parameter]
        [EditorRequired]
        public string Label { get; set; }
        [Parameter]
        public bool Disabled { get; set; } = false;
        async Task OnChange()
        {
           
            await ValueChanged.InvokeAsync(Value);
        }
        protected TValue _value;
        [Parameter]
        public TValue Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!EqualityComparer<TValue>.Default.Equals(value, _value))
                {
                    _value = value;
                }
            }
        }
        [Parameter]
        public EventCallback< TValue> ValueChanged { get; set; }

        [Parameter]
        public string Regex { get; set; } = "";

        [Parameter]
        public string RegexError { get; set; } = "";
        [Parameter]
        public TValue TargetValue { get; set; }
        bool IsRegexValidator => Regex == "" ? false : true;
    }
}
