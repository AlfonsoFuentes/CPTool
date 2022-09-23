


namespace CPTool.Pages.Components
{
    public partial class ComponentAutoComplete<TDTO, T> :
        CancellableComponent, IDisposable
        where TDTO : AuditableEntityDTO, new()
        where T : AuditableEntity, new()
    {
        [Parameter]
        [EditorRequired]
        public string TableName { get; set; }

        public string RequiredError => Required ? "" : $"Must submit {Label} ";
        [Parameter]
        public bool Required { get; set; } = false;
        [Parameter]
        [EditorRequired]
        public string Label { get; set; }
        [Parameter]
        public AuditableEntityDTO Parent { get; set; }
        [Parameter]
        public TDTO Model { get; set; } = new();

        [Parameter]
        public bool Disable { get; set; } = false;
        [Parameter]
        [Category(CategoryTypes.FormComponent.Validation)]
        public object Validation { get; set; }

        [Parameter]
        public EventCallback<TDTO> ModelChanged { get; set; }
        [Parameter]
        [EditorRequired]
        public IDTOManager<TDTO, T> Manager { get; set; }

        //[Parameter]
        //public Func<Task> UpdateList { get; set; }

        [Parameter]
      
        public List<TDTO> ObjectList { get; set; } = new();
        [Parameter]
        public EventCallback<List<TDTO>> ObjectListChanged { get; set; }
        [Parameter]
        public Func<TDTO, Task<DialogResult>> ShowDialogOverrided { get; set; }
        List<string> ListNames => ObjectList.Select(x => x.Name).ToList();


        private bool resetValueOnEmptyText = true;
        private bool coerceText = true;
        private bool coerceValue = true;
        private bool Inmediate = true;

        protected override void OnInitialized()
        {



            if (Model != null && Model.Id != 0)
            {

                AutocompleteText = Model.Name;
            }

            base.OnInitialized();
        }
        protected override void OnParametersSet()
        {

            if (Model == null)
            {
                AutocompleteText = "";
                return;
            }
            if (Model.Id != 0)
            {

                AutocompleteText = Model.Name;
            }
            else
            {
                if (!CreatingNewRow) AutocompleteText = "";
            }
        }
        bool CreatingNewRow = false;
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
                Model = new();


            }
            else if (IsExist)
            {
                Model = ObjectList.FirstOrDefault(x => x.Name == AutocompleteText);



            }
            else
            {
                Model = new();
                Model.Name = AutocompleteText;

                CreatingNewRow = true;
            }

            await ModelChanged.InvokeAsync(Model);

        }


        async Task KeyUp(KeyboardEventArgs arg)
        {
            if (arg.Code == "Enter" && !IsExist)
            {
                await ShowDialog();
            }
        }
        async Task ShowDialog()
        {
            DialogResult dialogResult = await ToolDialogService.ShowMessageDialogYesNo($"{AutocompleteText} is not in the table {TableName}. Do you want to add it? ");


            if (!dialogResult.Cancelled)
            {
                Model = new();

                Model.Name = AutocompleteText;

                if (Parent != null)
                    Model.Master = Parent;

                dialogResult = ShowDialogOverrided == null ? await ToolDialogService.ShowDialogName<TDTO>(Model) : await ShowDialogOverrided.Invoke(Model);


                if (!dialogResult.Cancelled)
                {
                    var created = await Manager.AddUpdate(Model, _cts.Token);
                    if (created.Succeeded)
                    {
                        CreatingNewRow = false;
                        Model = created.Data as TDTO;
                        await ModelChanged.InvokeAsync(Model);
                        await ObjectListChanged.InvokeAsync(Manager.List);
                        StateHasChanged();
                        //if (UpdateList != null) await UpdateList.Invoke();


                    }
                }
            }
        }

        void IDisposable.Dispose()
        {

        }
    }
}
