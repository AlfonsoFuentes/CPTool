using CPtool.ExtensionMethods;
using CPTool.Application.Features.Base;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CPTool2.NewPages.Components
{
    public partial class AutoCompleteComponent<TEdit, TList, TGedById>
        where TEdit : EditCommand, new()
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
        public TEdit Model { get; set; }

        [Parameter]
        [EditorRequired]
        public EventCallback<TEdit> SelectionChanged { get; set; }
        [Parameter]
        public List<TEdit> Elements { get; set; } = new();
        [Parameter]
        public EventCallback<List<TEdit>> ElementsChanged { get; set; }
        [Parameter]
        public Func<TEdit, Task<DialogResult>> ShowDialogOverrided { get; set; }
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
            if (Model!=null&&Model.Id != 0)
            {
                AutocompleteText = Model.Name;
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
                TEdit Model = new();

                if (Parent != null)
                {
                    Model = Parent.AddDetailtoMaster<TEdit>();
                }
                Model.Name = AutocompleteText;

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
                    await SelectionChanged.InvokeAsync(Model);
                    await ValidateForm.Invoke();

                }


            }
        }


    }
}