using CPTool.Application.Features.UnitFeatures.CreateEdit;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;
using Microsoft.AspNetCore.Components;

namespace CPTool.UIApp.AppPages.Templates
{
    public partial class SelectUnitTemplate
    {
        [Parameter]
        public string Format { get; set; } = "G6";
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public CommandUnit Model { get; set; }
        public CommandUnit LocalModel { get; set; }

        [Parameter]
        public EventCallback<CommandUnit> ModelChanged { get; set; }
        [Parameter]
        public bool Disable { get; set; }
      
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
           
            await ModelChanged.InvokeAsync(Model);
          
        }

        async Task OnValueChanged()
        {
            Model = LocalModel == null ? new() : LocalModel;
            await ModelChanged.InvokeAsync(Model);
            if (Change.HasDelegate) await Change.InvokeAsync();
        }
        [Parameter]
      
        public Func<Task> UpdateParent { get; set; }
        [Parameter]
        public EventCallback Change { get; set; }
    }
}
