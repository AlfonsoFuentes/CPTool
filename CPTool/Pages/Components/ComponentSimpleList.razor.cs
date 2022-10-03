

using CPTool.Pages.Classes;
using CPTool.Services;
using MediatR;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CPTool.Pages.Components;

//public partial class ComponentSimpleList<TCreate, TUpdate, TDelete, TList> : CancellableComponent
//    where TCreate : CreateCommand, new()
//    where TUpdate : UpdateCommand, new()
//    where TDelete : DeleteCommand, new()
//    where TList : ListCommand, new()
//{
//    [Inject]
//    public IMediator? mediator { get; set; }

//    [Parameter]
//    public Func<UpdateCommand, string, bool> SearchFunc { get; set; } = null!;
//    [Parameter]

//    public List<UpdateCommand> Elements { get; set; } = new();
//    [Parameter]
//    public EventCallback<List<UpdateCommand>> ElementsChanged { get; set; }
//    UpdateCommand Selected = new();
//    [Parameter]
//    public string TableName { get; set; }

//    [Parameter]
//    public Func<Commands, Task<DialogResult>> OnShowDialogOverrided { get; set; }
//    [Parameter]
//    public RenderFragment ContextTh { get; set; }
//    [Parameter]
//    public RenderFragment<UpdateCommand> ContextTd { get; set; }

//    protected override void OnInitialized()
//    {


//        base.OnInitialized();
//    }
//    async Task OnAdd()
//    {
//        TCreate model = new();
//        //var result = OnShowDialogOverrided == null ? await ToolDialogService.ShowDialogName<TCreate>(model) : await OnShowDialogOverrided.Invoke(model);

//        //if (!result.Cancelled)
//        //{
//        //    var result2 = await mediator!.Send(result.Data as TCreate, _cts.Token);
//        //    if (result2.Succeeded)
//        //    {
//        //        //Elements = await GetList.Handle();
//        //        await ElementsChanged.InvokeAsync(Elements);

//        //    }

//        //    StateHasChanged();
//        //}

//    }
//    async Task OnEdit(TUpdate model)
//    {

//        //var result = OnShowDialogOverrided == null ? await ToolDialogService.ShowDialogName<TUpdate>(model) : await OnShowDialogOverrided.Invoke(model);

//        //if (!result.Cancelled)
//        //{
//        //    var result2 = await mediator!.Send(result.Data as TUpdate, _cts.Token);
//        //    if (result2.Succeeded)
//        //    {
//        //        //Elements = await GetList.Handle();
//        //        await ElementsChanged.InvokeAsync(Elements);
//        //    }

//        //    StateHasChanged();
//        //}

//    }

//    async Task OnDelete(TUpdate dto)
//    {
//        //var result2 = await Manager.Delete(dto as TDTO, _cts.Token);
//        //if (result2.Succeeded)
//        //{
//        //    Elements = await GetList.Handle();
//        //    await ElementsChanged.InvokeAsync(Elements);
//        //}

//        StateHasChanged();


//    }
//}