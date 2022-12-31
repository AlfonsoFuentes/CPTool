using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Templates
{
    public partial class TextBoxTemplate
    {
        async Task OnChange(string sr)
        {
            Value = sr;
            await ValueChanged.InvokeAsync(Value);
        }
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        async Task OnChange(ChangeEventArgs arg)
        {
            Value = arg.Value.ToString();
            await ValueChanged.InvokeAsync(Value);
        }



        [Parameter]
        public bool Disabled { get; set; } = false;


        [Parameter]
        public int Rows { get; set; } = 1;
    }
}
