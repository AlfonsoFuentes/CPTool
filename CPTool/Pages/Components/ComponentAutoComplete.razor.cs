


namespace CPTool.Pages.Components
{
    //public partial class ComponentAutoComplete<TDTO, T> :
    //    CancellableComponent
    //    where TDTO : AuditableEntityDTO, new()
    //    where T : AuditableEntity, new()
    //{
    //    [Parameter]
    //    [EditorRequired]
    //    public string TableName { get; set; }

    //    public string RequiredError => Required ? "" : $"Must submit {Label} ";
    //    [Parameter]
    //    public bool Required { get; set; } = false;
    //    [Parameter]
    //    [EditorRequired]
    //    public string Label { get; set; }
    //    [Parameter]
    //    public AuditableEntityDTO Parent { get; set; }
    //    [Parameter]
    //    public TDTO Model { get; set; } = new();

    //    [Parameter]
    //    public bool Disable { get; set; } = false;
    //    [Parameter]
    //    [Category(CategoryTypes.FormComponent.Validation)]
    //    public object Validation { get; set; }

    //    [Parameter]
    //    public EventCallback<TDTO> ModelChanged { get; set; }
    //    [Inject]
       
    //    public IDTOManager<TDTO, T> Manager { get; set; }
    //    [Inject]

    //    public IGetList<TDTO, T> GetList { get; set; }

    //    [Parameter]
    //    public List<TDTO> ElementsService { get; set; } = new();
    //    [Parameter]
    //    [EditorRequired]
    //    public List<TDTO> Elements { get; set; } = new();
    //    [Parameter]
    //    public EventCallback<List<TDTO>> ElementsServiceChanged { get; set; }
    //    [Parameter]
    //    public Func<AuditableEntityDTO, Task<DialogResult>> ShowDialogOverrided { get; set; }
    //    List<string> ListNames => Elements.Select(x => x.Name).ToList();


    //    private bool resetValueOnEmptyText = true;
    //    private bool coerceText = true;
    //    private bool coerceValue = true;
    //    private bool Inmediate = true;

    //    protected override void OnInitialized()
    //    {

            

    //        if (Model != null && Model.Id != 0)
    //        {

    //            AutocompleteText = Model.Name;
    //        }

    //        base.OnInitialized();
    //    }
        
    //    bool CreatingNewRow = false;
    //    private async Task<IEnumerable<string>> SearchAsync(string value)
    //    {
    //        // In real life use an asynchronous function for fetching data from an api.
    //        await Task.Delay(5);

    //        // if text is null or empty, show complete list
    //        if (string.IsNullOrEmpty(value))
    //        {
    //            return ListNames;
    //        }

    //        return ListNames.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    //    }

    //    bool IsExist => ListNames.Contains(AutocompleteText);
    //    string AutocompleteText = "";


    //    async Task ValueChanged(string name)
    //    {
    //        AutocompleteText = name;
    //        if (AutocompleteText == null)
    //        {
    //            Model = new();


    //        }
    //        else if (IsExist)
    //        {
    //            Model = Elements.FirstOrDefault(x => x.Name == AutocompleteText);



    //        }
    //        else
    //        {
    //            Model = new();
    //            Model.Name = AutocompleteText;

    //            CreatingNewRow = true;
    //        }

    //        await ModelChanged.InvokeAsync(Model);

    //    }


    //    async Task KeyUp(KeyboardEventArgs arg)
    //    {
    //        if (arg.Code == "Enter" && !IsExist)
    //        {
    //            await ShowDialog();
    //        }
    //    }
    //    async Task ShowDialog()
    //    {
    //        DialogResult dialogResult = await ToolDialogService.ShowMessageDialogYesNo($"{AutocompleteText} is not in the table {TableName}. Do you want to add it? ");


    //        if (!dialogResult.Cancelled)
    //        {
    //            Model = new();

    //            Model.Name = AutocompleteText;

    //            if (Parent != null)
    //                Model.Master = Parent;

    //            dialogResult = ShowDialogOverrided == null ? await ToolDialogService.ShowDialogName<TDTO>(Model) : await ShowDialogOverrided.Invoke(Model);


    //            if (!dialogResult.Cancelled)
    //            {
    //                var created = await Manager.AddUpdate(Model, _cts.Token);
    //                if (created.Succeeded)
    //                {
    //                    Elements = await GetList.Handle();
    //                    StateHasChanged();
    //                    CreatingNewRow = false;
    //                    Model = Elements.Last();/* created.Data as TDTO;*/
    //                    await ModelChanged.InvokeAsync(Model);
    //                    await ElementsServiceChanged.InvokeAsync(Elements);
                       
                       


    //                }
    //            }
    //        }
    //    }

        
    //}
}
