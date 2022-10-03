




using System.ComponentModel.DataAnnotations;

namespace CPTool.Pages.Components
{
    //public partial class ComponentOneToManyList<MasterTDTO, MasterT, DetailDTO, DetailT> : CancellableComponent, IDisposable
    //    where MasterTDTO : AuditableEntityDTO, new()
    //    where MasterT : AuditableEntity, new()
    //     where DetailDTO : AuditableEntityDTO, new()
    //    where DetailT : AuditableEntity, new()
    //{
    //    [Inject]
    //    public IDTOManager<MasterTDTO, MasterT> MasterManager { get; set; }
    //    [Inject]
    //    public IDTOManager<DetailDTO, DetailT> DetailManager { get; set; }
    //    [Inject]
    //    public IGetList<MasterTDTO, MasterT> MasterList { get; set; }
    //    [Inject]
    //    public IGetList<DetailDTO, DetailT> DetailList { get; set; }

    //    [Parameter]
    //    public Func<MasterTDTO, string, bool> SearchFuncMaster { get; set; } = null;

    //    [Parameter]
    //    public Func<DetailDTO, string, bool> SearchFuncDetail { get; set; } = null;

    //    [Parameter]
    //    public string MasterTableName { get; set; }
    //    [Parameter]
    //    public string DetailTableName { get; set; }
    //    [Parameter]
    //    public Func<AuditableEntityDTO, Task<DialogResult>> OnShowDialogMaster { get; set; }
    //    [Parameter]
    //    public Func<AuditableEntityDTO, Task<DialogResult>> OnShowDialogDetail { get; set; }
    //    [Parameter]
    //    public MasterTDTO SelectedMaster { get; set; } = new();
    //    [Parameter]
    //    public DetailDTO SelectedDetail { get; set; } = new();

    //    [Parameter]
    //    public EventCallback<MasterTDTO> SelectedMasterChanged { get; set; }
    //    [Parameter]
    //    public EventCallback<DetailDTO> SelectedDetailChanged { get; set; }
    //    [Parameter]
      
    //    public List<MasterTDTO> MastersService { get; set; } = new();
    //    [Parameter]
    //    public List<MasterTDTO> Masters { get; set; } = new();
    //    [Parameter]
    //    public EventCallback<List<MasterTDTO>> MastersServiceChanged { get; set; }
    //    [Parameter]
    //    public List<DetailDTO> Details { get; set; } = new();
    //    [Parameter]
       
    //    public List<DetailDTO> DetailsService { get; set; } = new();
    //    [Parameter]
    //    public EventCallback<List<DetailDTO>> DetailsServiceChanged { get; set; }
    //    [Parameter]
    //    public RenderFragment OtherButtonMaster { get; set; }
    //    [Parameter]
    //    public RenderFragment OtherButtonDetail { get; set; }
    //    [Parameter]
    //    public RenderFragment ContextThMaster { get; set; }
    //    [Parameter]
    //    public RenderFragment<MasterTDTO> ContextTdMaster { get; set; }
    //    [Parameter]
    //    public RenderFragment ContextThDetail { get; set; }
    //    [Parameter]
    //    public RenderFragment<DetailDTO> ContextTdDetail { get; set; }
    //    string PageTitle => $"Relation {MasterTableName} => {DetailTableName}";
    //    int mastersm => 6;
    //    int detailsm => 6;
    //    async Task RowMasterClicked(MasterTDTO dto)
    //    {
    //        SelectedMaster = dto;// await MasterManager.GetById(dto.Id);
    //        await SelectedMasterChanged.InvokeAsync(SelectedMaster);

    //        Details = SelectedMaster?.Details.Select(x => x as DetailDTO).ToList();
    //        SelectedDetail = new();
    //        await SelectedDetailChanged.InvokeAsync(SelectedDetail);
    //        StateHasChanged();
    //    }
    //    async Task RowDetailClicked(DetailDTO dto)
    //    {

    //        SelectedDetail = dto;// await DetailManager.GetById(dto.Id);

    //        await SelectedDetailChanged.InvokeAsync(SelectedDetail);
    //    }

    //    protected override void OnInitialized()
    //    {

    //        base.OnInitialized();
    //    }
    //    async Task OnAddMaster()
    //    {
    //        MasterTDTO model = new();
    //        var result = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<MasterTDTO>(model) : await OnShowDialogMaster.Invoke(model);

    //        if (!result.Cancelled)
    //        {
    //            var result2 = await MasterManager.AddUpdate(result.Data as MasterTDTO, _cts.Token);
    //            if (result2.Succeeded)
    //            {
    //                Masters = await MasterList.Handle();
    //                await MastersServiceChanged.InvokeAsync(Masters);
    //                await RowMasterClicked(Masters.Last());

    //            }
    //            StateHasChanged();
    //        }

    //    }
    //    async Task OnEditMaster(MasterTDTO model)
    //    {

    //        var result = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<MasterTDTO>(model) : await OnShowDialogMaster.Invoke(model);

    //        if (!result.Cancelled)
    //        {
    //            var result2 = await MasterManager.AddUpdate(result.Data as MasterTDTO, _cts.Token);
    //            if (result2.Succeeded)
    //            {
    //                Masters = await MasterList.Handle();
    //                await MastersServiceChanged.InvokeAsync(Masters);
    //                await RowMasterClicked(Masters.Last());
    //            }
    //            StateHasChanged();
    //        }

    //    }

    //    async Task OnAddDetail()
    //    {
    //        DetailDTO model = new();
    //        var result = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<DetailDTO>(model) : await OnShowDialogDetail.Invoke(model);

    //        if (!result.Cancelled)
    //        {
    //            SelectedDetail= result.Data as DetailDTO;
    //            SelectedMaster.Details.Add(SelectedDetail);

    //            var result2 = await MasterManager.AddUpdate(SelectedMaster, _cts.Token);
    //            if (result2.Succeeded)
    //            {
    //                Masters = await MasterList.Handle();
    //                DetailsService = await DetailList.Handle();
    //                await MastersServiceChanged.InvokeAsync(Masters);
    //                await DetailsServiceChanged.InvokeAsync(DetailsService);
    //                SelectedMaster=await MasterManager.GetById(SelectedMaster.Id);
    //                await RowMasterClicked(SelectedMaster);
    //            }

    //            StateHasChanged();
    //        }

    //    }
    //    async Task OnEditDetail(DetailDTO model)
    //    {

    //        var result = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<DetailDTO>(model) : await OnShowDialogDetail.Invoke(model);

    //        if (!result.Cancelled)
    //        {

    //            model = result.Data as DetailDTO;

    //            var result2 = await DetailManager.AddUpdate(model, _cts.Token);
    //            if (result2.Succeeded)
    //            {
    //                Masters = await MasterList.Handle();
    //                DetailsService = await DetailList.Handle();
    //                await MastersServiceChanged.InvokeAsync(Masters);
    //                await DetailsServiceChanged.InvokeAsync(DetailsService);
    //                SelectedMaster = await MasterManager.GetById(SelectedMaster.Id);
    //                await RowMasterClicked(SelectedMaster);
    //            }
    //            StateHasChanged();
    //        }

    //    }


    //    async Task OnDeleteMaster(IAuditableEntityDTO dto)
    //    {
    //        if (dto is MasterTDTO)
    //        {

    //            var result = await MasterManager.Delete(dto as MasterTDTO, _cts.Token);
    //            if (result.Succeeded)
    //            {
    //                Masters = await MasterList.Handle();
    //                await MastersServiceChanged.InvokeAsync(Masters);
    //                SelectedMaster = new();
    //                await RowMasterClicked(SelectedMaster);
    //            }
    //            SelectedMaster = new();

    //            StateHasChanged();



    //        }


    //    }
    //    async Task OnDeleteDetail(IAuditableEntityDTO dto)
    //    {

    //        if (dto is DetailDTO)
    //        {

    //            var result = await DetailManager.Delete(dto as DetailDTO, _cts.Token);
    //            if (result.Succeeded)
    //            {
    //                Masters = await MasterList.Handle();
    //                await MastersServiceChanged.InvokeAsync(Masters);
    //                DetailsService = await DetailList.Handle();
    //                await DetailsServiceChanged.InvokeAsync(DetailsService);
    //                SelectedMaster = await MasterManager.GetById(SelectedMaster.Id);
    //                await RowMasterClicked(SelectedMaster);
    //            }

    //            StateHasChanged();


    //        }

    //    }



    //}
}
