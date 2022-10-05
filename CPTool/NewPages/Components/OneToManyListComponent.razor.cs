

namespace CPTool.NewPages.Components
{
    public partial class OneToManyListComponent<TMaster, TDetail, TMasterList, TDetailList, TDeleteMaster, TDeleteDetail, TMasterGedById, TDetailGedById>
        where TMaster : AddEditCommand, new()
        where TDetail : AddEditCommand, new()
        where TMasterList : GetListQuery, new()
        where TDetailList : GetListQuery, new()
        where TDeleteMaster : DeleteCommand, new()
        where TDeleteDetail : DeleteCommand, new()
        where TMasterGedById : GetByIdQuery, new()
        where TDetailGedById : GetByIdQuery, new()
    {

        [Inject]
        public IMediator mediator { get; set; }

        TMasterList MasterList { get; set; } = new();
        TDetailList DetailList { get; set; } = new();
        List<TMaster> ElementsMasters { get; set; } = new();

        [Parameter]
        [EditorRequired]
        public List<TDetail> ElementsDetails { get; set; } = new();

        [Parameter]

        public TMaster SelectedMaster { get; set; } = new();
        [Parameter]
        public EventCallback<TMaster> SelectedMasterChanged { get; set; }
        [Parameter]

        public TDetail SelectedDetail { get; set; } = new();
        [Parameter]
        public EventCallback<TDetail> SelectedDetailChanged { get; set; }
        [Parameter]
        public RenderFragment OtherButtons { get; set; }

        [Parameter]
        public RenderFragment MasterContextTh { get; set; }
        [Parameter]
        public RenderFragment<TMaster> MasterContextTd { get; set; }

        [Parameter]
        public RenderFragment DetailContextTh { get; set; }
        [Parameter]
        public RenderFragment<TDetail> DetailContextTd { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TMaster, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TDetail, Task<DialogResult>> OnShowDialogDetails { get; set; }



        protected override async Task OnInitializedAsync()
        {
            ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
        }

        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> eq)
        {

            TMasterGedById getbyid = new()
            {
                Id = eq.Item.Id,
            };
            SelectedMaster = await mediator.Send(getbyid) as TMaster;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);
        }
        async Task RowClickedDetail(TableRowClickEventArgs<TDetail> eq)
        {

            TDetailGedById getbyid = new()
            {
                Id = eq.Item.Id,
            };
            SelectedDetail = await mediator.Send(getbyid) as TDetail;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }
        async Task Add()
        {
            TMaster model = new();

            var result = await OnShowDialogMaster.Invoke(model);
            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);

                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;

            }

        }

        async Task Edit()
        {

            var result = await OnShowDialogMaster.Invoke(SelectedMaster);

            if (!result.Cancelled)
            {
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;

            }
        }
        async Task Delete()
        {
            TDeleteMaster ModelDelete = new() { Id = SelectedMaster.Id, Name = SelectedMaster.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                SelectedMaster = new();
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);

            }


        }
        async Task AddDetail()
        {
            TDetail model = SelectedMaster.AddDetailtoMaster() as TDetail;

            var result = await OnShowDialogDetails.Invoke(model);
            if (!result.Cancelled)
            {
                var data = result.Data as TDetail;
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                TMasterGedById query = new() { Id = SelectedMaster.Id };

                SelectedMaster = (await mediator.Send(query)) as TMaster;
                TDetailGedById querydetail = new() { Id = data.Id };

                SelectedDetail = (await mediator.Send(querydetail)) as TDetail;
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);
                await SelectedDetailChanged.InvokeAsync(SelectedDetail);
            }

        }

        async Task EditDetail()
        {
            var result = await OnShowDialogDetails.Invoke(SelectedDetail);

            if (!result.Cancelled)
            {
                var data = result.Data as TDetail;
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                TMasterGedById query = new() { Id = SelectedMaster.Id };

                SelectedMaster = (await mediator.Send(query)) as TMaster;
                TDetailGedById querydetail = new() { Id = data.Id };

                SelectedDetail = (await mediator.Send(querydetail)) as TDetail;
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);
                await SelectedDetailChanged.InvokeAsync(SelectedDetail);
            }
        }

        async Task DeleteDetail()
        {
            TDeleteDetail deleteDetail = new() { Id = SelectedDetail.Id, Name = SelectedDetail.Name };

            var result = await ToolDialogService.DeleteRow(deleteDetail);
            if (!result.Cancelled)
            {
                SelectedDetail = new();
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                TMasterGedById query = new() { Id = SelectedMaster.Id };

                SelectedMaster = (await mediator.Send(query)) as TMaster;

                await SelectedMasterChanged.InvokeAsync(SelectedMaster);

            }


        }

    }
}
