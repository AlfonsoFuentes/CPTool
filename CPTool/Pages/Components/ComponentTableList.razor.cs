


using CPTool.Pages.Classes;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CPTool.Pages.Components
{
    //public partial class ComponentTableList : CancellableComponent
    //{

    //    private bool hover = true;
    //    private bool striped = true;
    //    private bool bordered = true;
    //    private string searchString1 = "";
    //    private bool dense = true;
    //    [Parameter]
    //    public RenderFragment OtherButtons { get; set; }
    //    [Parameter]
    //    public RenderFragment ContextTh { get; set; }
    //    [Parameter]
    //    public RenderFragment<UpdateCommand> ContextTd { get; set; }



    //    [Parameter]
    //    public List<UpdateCommand> Elements { get; set; } = new();
    //    [Parameter]
    //    public EventCallback<List<UpdateCommand>> ElementsChanged { get; set; }
    //    [Parameter]
    //    [EditorRequired]
    //    public UpdateCommand SelectedItem { get; set; } = null!;

    //    [Parameter]
    //    public string TableName { get; set; }
    //    [Parameter]
    //    public EventCallback<UpdateCommand> OnRowClickEvent { get; set; }

    //    [Parameter]
    //    public EventCallback OnAdd { get; set; }

    //    [Parameter]
    //    public EventCallback<UpdateCommand> OnEdit { get; set; }

    //    [Parameter]
    //    public EventCallback<UpdateCommand> OnDelete { get; set; }

    //    [Parameter]
    //    public Func<UpdateCommand, Task<DialogResult>> OnShowDialogOverrided { get; set; }

    //    [Parameter]
    //    public EventCallback OnUpdateMaster { get; set; }

       

    //    private bool FilterFunc1(UpdateCommand element) => FilterFunc(element, searchString1);

    //    [Parameter]
    //    public static Func<UpdateCommand, string, bool> SearchFunc { get; set; } = null!;

    //    private bool FilterFunc(UpdateCommand element, string searchString)
    //    {
    //        var retorno =  SearchFunc == null ? element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) : SearchFunc.Invoke(element, searchString);
    //        return retorno;


    //    }

    //    async Task RowClickEvent(TableRowClickEventArgs<UpdateCommand> arg)
    //    {
    //        SelectedItem = arg.Item;
    //        await OnRowClickEvent.InvokeAsync(SelectedItem);
    //    }

    //    async Task Add()
    //    {
    //        await OnAdd.InvokeAsync();


    //    }

    //    async Task Edit()
    //    {
    //        await OnEdit.InvokeAsync(SelectedItem);

    //    }

    //    async Task Delete()
    //    {

    //        await OnDelete.InvokeAsync(SelectedItem);


    //    }
    //    void Print()
    //    {

    //    }
    //    void Excel()
    //    {

    //    }
    //    void PDF()
    //    {

    //    }

    //}
}
