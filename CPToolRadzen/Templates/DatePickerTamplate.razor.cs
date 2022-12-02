using Microsoft.AspNetCore.Components;
using System;

namespace CPToolRadzen.Templates
{
    public partial class DatePickerTamplate
    {
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public DateTime? Value { get; set; } = DateTime.Now;
        [Parameter]
        public EventCallback<DateTime?> ValueChanged { get; set; }

        async Task OnChange()
        {
           
            await ValueChanged.InvokeAsync(Value);
        }

        string RequiredText => $"{Label} is required";
        [Parameter]
        public bool Required { get; set; } = false;
        [Parameter]
        public bool Disabled { get; set; } = false;

 

       
    }
}
