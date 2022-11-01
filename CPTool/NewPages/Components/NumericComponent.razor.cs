using CPtool.ExtensionMethods;
using System.Globalization;

namespace CPTool.NewPages.Components
{
    public partial class NumericComponent<T> where T : EditCommand
    {
        [Parameter]
        public bool Disable { get; set; } = false;
        [Parameter]
        [EditorRequired]
        public string PropertyName { get; set; } = string.Empty;

        [Parameter]
        public T Model { get; set; }
        [Parameter]
        public EventCallback<T> ModelChanged { get; set; }
        [Parameter]
        public string RequiredError { get; set; }
        [Parameter]
        public bool Required { get; set; }
        [Parameter]
        public string Label { get; set; }

        public InputMode InputMode => InputMode.numeric;

        [Parameter]
        public IMask Mask { get; set; } = new RegexMask(@"^[0-9]");
        [Parameter]
        [Category(CategoryTypes.FormComponent.Validation)]
        public object Validation { get; set; }

        protected override void OnInitialized()
        {
            StringValue = Model.GetType().GetProperty(PropertyName).GetValue(Model).ToString();
        }
        string StringValue { get; set; }


        async Task OnValueChanged(string str)
        {
            SetValue(str);

            await ModelChanged.InvokeAsync(Model);
        }
        void SetValue(string str)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            var type = Model.GetType().GetProperty(PropertyName).GetValue(Model, null);
            switch (type)
            {
                case float:
                    {
                        float val = str.ToFloat();
                        //if (float.TryParse(str, out val))
                        //{
                        //    Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);
                        //}

                    }
                    break;
                case int:
                    {
                        int val = str.ToInt();
                        Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);
                        //if (int.TryParse(str, out val))
                        //{
                        //    Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);
                        //}
                    }
                    break;
                case double:
                    {
                        double val = str.ToDouble();
                        Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);
                        //if (double.TryParse(str, out val))
                        //{
                        //    Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);
                        //}
                    }
                    break;
                case decimal:
                    {
                        decimal val = str.ToDecimal();
                        Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);
                        //if (decimal.TryParse(str, out val))
                        //{
                        //    Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);
                        //}
                    }
                    break;
            }
            //Model.GetType().GetProperty(PropertyName).SetValue(Model, val, null);

            StringValue = Model.GetType().GetProperty(PropertyName).GetValue(Model).ToString();

        }
    }
}
