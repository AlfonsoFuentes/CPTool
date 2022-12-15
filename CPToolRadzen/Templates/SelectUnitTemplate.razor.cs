using CPTool.Application.Features.UnitFeatures.CreateEdit;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Templates
{
    public partial class SelectUnitTemplate
    {
        [Parameter]
        public string Format { get; set; } = "G6";
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public EditUnit Model { get; set; }
        public EditUnit LocalModel { get; set; }
        [Parameter]
        public EventCallback<EditUnit> ModelChanged { get; set; }
        [Parameter]
        public bool Disable { get; set; }
        [Parameter]
        public bool Required { get; set; } = false;

        string RequiredText => $"{Label} is required";
        [Parameter]
        public string Regex { get; set; } = "";

        [Parameter]
        public string RegexError { get; set; } = "";
        [Parameter]
        public double TargetValue { get; set; }
        bool IsRegexValidator => Regex == "" ? false : true;
        protected override void OnInitialized()
        {
            LocalModel = Model == null ? new() : Model;
            base.OnInitialized();
        }
        async Task UnitChanged()
        {
            Model = LocalModel == null ? new() : LocalModel;
            await ModelChanged.InvokeAsync(Model);
          
        }

        async Task OnValueChanged()
        {

            await ModelChanged.InvokeAsync(Model);
            if (Change.HasDelegate) await Change.InvokeAsync();
        }
        [Parameter]
      
        public Func<Task> UpdateParent { get; set; }
        [Parameter]
        public EventCallback Change { get; set; }
    }
}
