using Microsoft.Extensions.Primitives;
using MudBlazor;
using System;

namespace CPTool.NewPages.Components.Forms
{
    public partial class TextComponent<T> where T : EditCommand
    {
        [Parameter]
        public bool Disable { get; set; } = false;
        [Parameter]
        [EditorRequired]
        public string PropertyName { get; set; } = string.Empty;
        [Parameter]
        public int Lines { get; set; } = 1;
        [Parameter]
        public T Model { get; set; }
        [Parameter]
        public EventCallback<T> ModelChanged { get; set; }
        string _requirederror;

        string OnRequiredError(string valor)
        {
            if (valor != "") return valor;
            else if (Required) return $"Must define {Label}";
            return "";
        }
        [Parameter]
        public string RequiredError { get => OnRequiredError(""); set => _requirederror = OnRequiredError(value); }
        [Parameter]
        public bool Required { get; set; }
        [Parameter]
        public string Label { get; set; }

        public InputMode InputMode => InputMode.text;
        [Parameter]
        public InputType InputType { get; set; } = InputType.Text;


        [Parameter]
        [Category("Data")]
        public IMask Mask { get; set; }
        [Parameter]
        [Category(CategoryTypes.FormComponent.Validation)]
        public object Validation { get; set; }

        protected override void OnInitialized()
        {
            StringValue = "";
            if (Model != null )
            {
                var properties = Model.GetType().GetProperties();
                if (properties.Any(x => x.Name == PropertyName))
                    StringValue = Model.GetType().GetProperty(PropertyName).GetValue(Model).ToString();
            }
        }
        string StringValue { get; set; }


        async Task OnValueChanged(string str)
        {
            StringValue = str;
            var properties = Model.GetType().GetProperties();
            if (properties.Any(x => x.Name == PropertyName))
                Model.GetType().GetProperty(PropertyName).SetValue(Model, str, null);
            await ModelChanged.InvokeAsync(Model);
        }
    }
}
