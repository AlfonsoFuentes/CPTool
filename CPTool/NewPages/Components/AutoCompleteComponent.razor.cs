using CPtool.ExtensionMethods;
using Microsoft.Extensions.Primitives;

namespace CPTool.NewPages.Components
{
    public partial class AutoCompleteComponent<TEdit, TList, TGedById>
        where TEdit : EditCommand, new()
        where TGedById : GetByIdQuery, new()

        where TList : GetListQuery, new()
    {
       
        TList ModelList = new();
        [Parameter]
        [EditorRequired]
        public string TableName { get; set; }
        [Parameter]
        [EditorRequired]
        public string PropertyName { get; set; } = string.Empty;
        //TList ModelList = new();

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

        public TEdit Model { get; set; }
        [Parameter]
        public EventCallback<TEdit> ModelChanged { get; set; }
        [Parameter]
        public EventCallback<TEdit> SelectionChanged { get; set; }
        [Parameter]
        public List<TEdit> Elements { get; set; } = new();
        [Parameter]
        public EventCallback<List<TEdit>> ElementsChanged { get; set; }
        [Parameter]
        public Func<TEdit, Task<DialogResult>> ShowDialogOverrided { get; set; }
        List<string> ListNames => Elements.Select(x => x.Name).ToList();
        [Parameter]
       
        public Func<Task> ValidateForm { get; set; }
        [Parameter]
        public Func<Task> UpdateMasterParent { get; set; } //For use in master details relation

        private bool resetValueOnEmptyText = true;
        private bool coerceText = true;
        private bool coerceValue = true;
        private bool Inmediate = true;

        protected override void OnInitialized()
        {
            if (Model != null && Model.Id != 0)
            {
                AutocompleteText = Model.GetType().GetProperty(PropertyName).GetValue(Model).ToString();
            }
            else
            {
                AutocompleteText = "";
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
                Model.GetType().GetProperty(PropertyName).SetValue(Model, AutocompleteText, null);
               

                //CreatingNewRow = true;
            }


            if (SelectionChanged.HasDelegate) await SelectionChanged.InvokeAsync(Model);
            await ModelChanged.InvokeAsync(Model);
            if(ValidateForm!=null) await ValidateForm.Invoke();

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
                TEdit Model = new();

                if (Parent != null)
                {
                    Model = Parent.AddDetailtoMaster<TEdit>();
                }
                Model.GetType().GetProperty(PropertyName).SetValue(Model, AutocompleteText, null);

                dialogResult = ShowDialogOverrided == null ? await ToolDialogService.ShowNameDialog(Model) : await ShowDialogOverrided.Invoke(Model);

                if (!dialogResult.Cancelled)
                {
                    var data = dialogResult.Data as TEdit;
                    if (Parent != null)
                    {

                        await UpdateMasterParent.Invoke();
                    }
                    else
                    {
                        Elements = await Mediator.Send(ModelList) as List<TEdit>;
                        await ElementsChanged.InvokeAsync(Elements);

                    }
                    TGedById gedById = new() { Id = data.Id };
                    Model = await Mediator.Send(gedById) as TEdit;
                    if (SelectionChanged.HasDelegate) await SelectionChanged.InvokeAsync(Model);
                    await ModelChanged.InvokeAsync(Model);
                    if (ValidateForm != null) await ValidateForm.Invoke();

                }


            }
        }


    }
}