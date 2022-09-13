


using System.Linq.Expressions;

namespace CPTool.Pages.Components
{
    public partial class ComponentAutoCompleteText<TDTO, T> :
        CancellableComponent, IDisposable
        where TDTO : AuditableEntityDTO, new()
        where T : AuditableEntity, new()
    {
       
        [Parameter]
        public string RequiredError { get; set; }
        [Parameter]
        public bool Required { get; set; }
        [Parameter]
        public string Label { get; set; }
        
        [Parameter]
        public string Model { get; set; } = "";
        [Parameter]
        public bool Disable { get; set; } = false;
       
        [Parameter]
        public EventCallback<string> ModelChanged { get; set; }
        [Parameter]
        [EditorRequired]
        public IDTOManager<TDTO, T> Manager { get; set; }


       
        [Parameter]
        public Func<TDTO, string> Expresion { get; set; }
        [Parameter]
        public Func<TDTO, Task<DialogResult>> ShowDialogOverrided { get; set; }
        List<string> ListNames => Manager.List.GroupBy(Expresion).Select(y => y.Key).ToList();


        private bool resetValueOnEmptyText = true;
        private bool coerceText = true;
        private bool coerceValue = true;
        private bool Inmediate = true;

        protected override void OnInitialized()
        {

            var list = Manager.List.GroupBy(Expresion).Select(y=>y.Key).ToList();
            AutocompleteText = Model;

            base.OnInitialized();
        }
        protected override void OnParametersSet()
        {

            AutocompleteText = Model;
            
        }
       
        private async Task<IEnumerable<string>> SearchAsync(string value)
        {
            // In real life use an asynchronous function for fetching data from an api.
            await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(value))
            {
                return ListNames;
            }

            return ListNames.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }

        bool IsExist => ListNames.Contains(AutocompleteText);
        string AutocompleteText = "";


        async Task ValueChanged(string name)
        {
            AutocompleteText = name;
            if (AutocompleteText == null)
            {
                Model = "";
            }
            else if (IsExist)
            {
                Model = ListNames.FirstOrDefault(x => x == AutocompleteText);
               
            }
            else
            {
                Model = AutocompleteText;
              
            }
           
            await ModelChanged.InvokeAsync(Model);
           
        }


      
    

        void IDisposable.Dispose()
        {

        }
    }
}
