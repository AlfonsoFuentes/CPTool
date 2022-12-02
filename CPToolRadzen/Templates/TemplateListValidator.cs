using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;
using System.ComponentModel.DataAnnotations;

namespace CPToolRadzen.Templates
{
    public class TemplateListValidator : ValidatorBase
    {
        [Parameter]
        public override string Text { get; set; } = "Value should match";

        [Parameter]
        [EditorRequired]
        public List<String> StringsToCompare { get; set; }
        protected override bool Validate(IRadzenFormComponent component)
        {
            var value = component.GetValue().ToString();

            var comparer = !StringsToCompare.Any(x => x == component.GetValue().ToString());
            return comparer;
        }
    }
}
