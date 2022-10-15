using CPtool.ExtensionMethods;

namespace CPTool.NewPages.Components
{
    public partial class AutoCompleteComponent<T, TAdd, TList, TGedById>
        where T : EditCommand, new()
      where TAdd : AddCommand, new()
        where TGedById : GetByIdQuery, new()
        where TList : GetListQuery, new()
    {
        [Inject]
        public IMediator Mediator { get; set; }

        [Parameter]
        [EditorRequired]
        public string TableName { get; set; }

        TList ModelList = new();

        public string RequiredError => Required ? "" : $"Must submit {Label} ";
        [Parameter]
        public bool Required { get; set; } = false;
        [Parameter]
        [EditorRequired]
        public string Label { get; set; }

        [Parameter]
        public EditCommand Parent { get; set; } = null!;

        [Parameter]
        public bool Disable { get; set; } = false;
        [Parameter]
        [Category(CategoryTypes.FormComponent.Validation)]
        public object Validation { get; set; }
        [Parameter]
        [EditorRequired]
        public T Model { get; set; } = new();

        [Parameter]
        [EditorRequired]
        public EventCallback<T> SelectionChanged { get; set; }
        [Parameter]
        public List<T> Elements { get; set; } = new();
        [Parameter]
        public EventCallback<List<T>> ElementsChanged { get; set; }
        [Parameter]
        public Func<T, Task<DialogResult>> ShowDialogOverrided { get; set; }
        List<string> ListNames => Elements.Select(x => x.Name).ToList();
        [Parameter]
        [EditorRequired]
        public Func<Task> ValidateForm { get; set; }
        [Parameter]
        public Func<Task> UpdateMasterParent { get; set; } //For use in master details relation

        private bool resetValueOnEmptyText = true;
        private bool coerceText = true;
        private bool coerceValue = true;
        private bool Inmediate = true;

        protected override void OnInitialized()
        {
            if (Model != null)
            {
                AutocompleteText = Model.Name;
            }

            base.OnInitialized();
        }

        //bool CreatingNewRow = false;
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
                Model = Elements.FirstOrDefault(x => x.Name == AutocompleteText);

            }
            else
            {
                Model = new();
                Model.Name = AutocompleteText;

                //CreatingNewRow = true;
            }


            await SelectionChanged.InvokeAsync(Model);
            await ValidateForm.Invoke();
        }


        async Task KeyUp(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs arg)
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
                TAdd modeladd = new();

                if (Parent != null)
                {
                    modeladd = Parent.AddDetailtoMaster<TAdd>();
                }
                else
                {
                    modeladd = new();
                }
                var resultadd = await Mediator.Send(modeladd) as Result<int>;
                if (resultadd.Succeeded)
                {
                    TGedById gedById = new() { Id = resultadd.Data };
                    Model = await Mediator.Send(gedById) as T;
                    dialogResult = ShowDialogOverrided == null ? await ToolDialogService.ShowNameDialog(Model) : await ShowDialogOverrided.Invoke(Model);

                    if (!dialogResult.Cancelled)
                    {
                        if (Parent != null)
                        {

                            await UpdateMasterParent.Invoke();
                        }
                        else
                        {
                            Elements = await Mediator.Send(ModelList) as List<T>;
                            await ElementsChanged.InvokeAsync(Elements);

                        }
                        Model = dialogResult.Data as T;
                        await SelectionChanged.InvokeAsync(Model);
                        await ValidateForm.Invoke();
                    }
                }


            }
        }


    }
}