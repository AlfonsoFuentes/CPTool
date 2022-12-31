using Microsoft.AspNetCore.Components;
using System;

namespace CPTool.UIApp.AppPages.Templates
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
        public bool Disabled { get; set; } = false;

 

       
    }
}
