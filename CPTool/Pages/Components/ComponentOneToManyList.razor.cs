



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
        MasterTDTO SelectedMaster = new();
        DetailDTO SelectedDetail = new();


        public List<MasterTDTO> Masters => MasterManager.List;
        List<DetailDTO> Details => SelectedMaster.Details.Select(x => x as DetailDTO).ToList();
        ComponentTableList<MasterTDTO, MasterT> tableMaster;
        ComponentTableList<DetailDTO, DetailT> tableDetail;

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
        void RowMasterClicked(MasterTDTO dto)
        {
            SelectedMaster = dto;


            SelectedDetail = new();
        }
        void RowDetailClicked(DetailDTO dto)
        {

            SelectedDetail = dto;

        }

        protected override void OnInitialized()
        {

           
            TablesService.Delete += OnDelete;
           

            base.OnInitialized();
        }


        async Task<DialogResult> ShowDialogMaster(AuditableEntityDTO dto)
        {
            TablesService.Save += OnSaveMaster;
            return OnShowDialogMaster == null ? await ToolDialogService.ShowDialogName<AuditableEntityDTO>(dto) : await OnShowDialogMaster.Invoke(dto);
        }


        async Task<DialogResult> ShowDialogDetail(AuditableEntityDTO dto)
        {
            TablesService.Save += OnSaveDetails;

            return OnShowDialogDetail == null ? await ToolDialogService.ShowDialogName<AuditableEntityDTO>(dto) : await OnShowDialogDetail.Invoke(dto);
        }

        async Task<IResult<IAuditableEntityDTO>> OnSaveMaster(IAuditableEntityDTO dto)
        {
            var result = await MasterManager.AddUpdate(dto, _cts.Token);
            if (result.Succeeded)
                SelectedMaster = result.Data;
            StateHasChanged();
            TablesService.Save -= OnSaveMaster;
            return result;

        }
        async Task<IResult<IAuditableEntityDTO>> OnSaveDetails(IAuditableEntityDTO dto)
        {
            var result = await DetailManager.AddUpdate(dto, _cts.Token);
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
          
                StateHasChanged();

                return result;

            }
            if (dto is DetailDTO)
            {
                var result = await DetailManager.Delete(dto.Id, _cts.Token);
                await MasterManager.UpdateList();
                SelectedMaster = MasterManager.List.FirstOrDefault(x => x.Id == SelectedMaster.Id);
                StateHasChanged();
                return result;

            }
            return await Result<int>.FailAsync("Not Value!");
        }
       
        void IDisposable.Dispose()
        {
          
            TablesService.Delete -= OnDelete;
           
        }

    }
}
