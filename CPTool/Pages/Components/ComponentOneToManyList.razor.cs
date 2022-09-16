



using System.ComponentModel.DataAnnotations;

namespace CPTool.Pages.Components
{
    public partial class ComponentOneToManyList<MasterTDTO, MasterT, DetailDTO, DetailT> : CancellableComponent, IDisposable
        where MasterTDTO : AuditableEntityDTO, new()
        where MasterT : AuditableEntity, new()
         where DetailDTO : AuditableEntityDTO, new()
        where DetailT : AuditableEntity, new()
    {
        [Parameter]
        public IDTOManager<MasterTDTO, MasterT> MasterManager { get; set; }
        [Parameter]
        public IDTOManager<DetailDTO, DetailT> DetailManager { get; set; }


        [Parameter]
        public string MasterTableName { get; set; }
        [Parameter]
        public string DetailTableName { get; set; }
        [Parameter]
        public Func<AuditableEntityDTO, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        public Func<AuditableEntityDTO, Task<DialogResult>> OnShowDialogDetail { get; set; }
        [Parameter]
        public MasterTDTO SelectedMaster { get; set; } = new();
        [Parameter]
        public DetailDTO SelectedDetail { get; set; } = new();

        [Parameter]
        public EventCallback<MasterTDTO> SelectedMasterChanged { get; set; }
        [Parameter]
        public EventCallback<DetailDTO> SelectedDetailChanged { get; set; }

        public List<MasterTDTO> Masters => MasterManager.List;
        List<DetailDTO> Details => SelectedMaster.Details.Select(x => x as DetailDTO).ToList();
        ComponentTableList<MasterTDTO, MasterT> tableMaster;
        ComponentTableList<DetailDTO, DetailT> tableDetail;
        [Parameter]
        public RenderFragment OtherButtonMaster { get; set; }
        [Parameter]
        public RenderFragment OtherButtonDetail { get; set; }
        [Parameter]
        public RenderFragment ContextThMaster { get; set; }
        [Parameter]
        public RenderFragment<MasterTDTO> ContextTdMaster { get; set; }
        [Parameter]
        public RenderFragment ContextThDetail { get; set; }
        [Parameter]
        public RenderFragment<DetailDTO> ContextTdDetail { get; set; }
        string PageTitle => $"Relation {MasterTableName} => {DetailTableName}";
        int mastersm => 6;
        int detailsm => 6;
        async Task RowMasterClicked(MasterTDTO dto)
        {
            SelectedMaster = dto;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);

            SelectedDetail = new();
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }
        async Task RowDetailClicked(DetailDTO dto)
        {

            SelectedDetail = dto;
        
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }

        protected override void OnInitialized()
        {

            DetailManager.PostUpdateListEvent += MasterManager.UpdateList;

            TablesService.Delete += OnDelete;
            base.OnInitialized();
        }


        async Task<DialogResult> ShowDialogMaster(AuditableEntityDTO dto)
        {
            TablesService.Save += OnSaveMaster;

            var retorno = OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<AuditableEntityDTO>(dto) : await OnShowDialogMaster.Invoke(dto);

            if (retorno.Cancelled) TablesService.Save -= OnSaveMaster;
            return retorno;
        }


        async Task<DialogResult> ShowDialogDetail(AuditableEntityDTO dto)
        {
            TablesService.Save += OnSaveDetails;
            if (dto.Id == 0) dto.Master = SelectedMaster;

            var retorno = OnShowDialogDetail == null ? await ToolDialogService.ShowDialogName<AuditableEntityDTO>(dto) : await OnShowDialogDetail.Invoke(dto);

            if (retorno.Cancelled) TablesService.Save -= OnSaveDetails;
            return retorno;
        }

        async Task<IResult<IAuditableEntityDTO>> OnSaveMaster(IAuditableEntityDTO dto)
        {
            var result = await MasterManager.AddUpdate(dto, _cts.Token);
            if (result.Succeeded)
                SelectedMaster = result.Data;
            await MasterManager.UpdateList();
            StateHasChanged();
            TablesService.Save -= OnSaveMaster;
            return result;

        }
        async Task<IResult<IAuditableEntityDTO>> OnSaveDetails(IAuditableEntityDTO dto)
        {
            var result = await DetailManager.AddUpdate(dto, _cts.Token);
            await DetailManager.UpdateList();
            await MasterManager.UpdateList();
            SelectedMaster = MasterManager.List.FirstOrDefault(x => x.Id == SelectedMaster.Id);

            StateHasChanged();
            TablesService.Save -= OnSaveDetails;
            return result;
        }


        async Task<IResult<int>> OnDelete(IAuditableEntityDTO dto)
        {
            if (dto is MasterTDTO)
            {
                SelectedMaster = new();
                var result = await MasterManager.Delete(dto.Id, _cts.Token);

                await MasterManager.UpdateList();
                StateHasChanged();

                return result;

            }
            if (dto is DetailDTO)
            {
                var result = await DetailManager.Delete(dto.Id, _cts.Token);
                await DetailManager.UpdateList();
                SelectedMaster = MasterManager.List.FirstOrDefault(x => x.Id == SelectedMaster.Id);
                StateHasChanged();
                return result;

            }
            return await Result<int>.FailAsync("Not Value!");
        }

        void IDisposable.Dispose()
        {
            DetailManager.PostUpdateListEvent -= MasterManager.UpdateList;
            TablesService.Delete -= OnDelete;

        }

    }
}
