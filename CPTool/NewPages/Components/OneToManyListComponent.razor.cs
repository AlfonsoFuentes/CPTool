



using CPtool.ExtensionMethods;

namespace CPTool.NewPages.Components
{
    public partial class OneToManyListComponent<TMaster, TDetail, TMasterList, TDetailList, TDeleteMaster, TDeleteDetail, TMasterGedById, TDetailGedById>
        where TMaster : EditCommand, new()

        where TDetail : EditCommand, new()

        where TMasterList : GetListQuery, new()
        where TDetailList : GetListQuery, new()
        where TDeleteMaster : Delete, new()
        where TDeleteDetail : Delete, new()
        where TMasterGedById : GetByIdQuery, new()
        where TDetailGedById : GetByIdQuery, new()
    {

        [Inject]
        public IMediator mediator { get; set; }

        TMasterList MasterList { get; set; } = new();
        TDetailList DetailList { get; set; } = new();
        [Parameter]
        public List<TMaster> ElementsMasters { get; set; } = new();
        [Parameter]
        public EventCallback<List<TMaster>> ElementsMastersChanged { get; set; }

        [Parameter]
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
        [EditorRequired]
        public RenderFragment MasterContextTh { get; set; }
        [Parameter]
        [EditorRequired]
        public RenderFragment<TMaster> MasterContextTd { get; set; }

        [Parameter]
        [EditorRequired]
        public RenderFragment DetailContextTh { get; set; }
        [Parameter]
        [EditorRequired]
        public RenderFragment<TDetail> DetailContextTd { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TMaster, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TDetail, Task<DialogResult>> OnShowDialogDetails { get; set; }



        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> eq)
        {
            if (eq.Item.Id == SelectedMaster.Id) return;
            TMasterGedById getbyid = new()
            {
                Id = eq.Item.Id,
            };
            SelectedMaster = await mediator.Send(getbyid) as TMaster;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);
        }
        async Task RowClickedDetail(TableRowClickEventArgs<TDetail> eq)
        {
            if (eq.Item.Id == SelectedDetail.Id) return;
            TDetailGedById getbyid = new()
            {
                Id = eq.Item.Id,
            };
            SelectedDetail =  await mediator.Send(getbyid) as TDetail;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }

        async Task Add()
        {

            TMaster model = new();
            var result = await OnShowDialogMaster.Invoke(model);
            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
                //TMasterGedById querydetail = new() { Id = data.Id };
                //SelectedMaster = await mediator.Send(querydetail) as TMaster;

                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);
            }
        }


        async Task Edit()
        {

            var result = await OnShowDialogMaster.Invoke(SelectedMaster);

            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
                //TMasterGedById querydetail = new() { Id = data.Id };
                //SelectedMaster = await mediator.Send(querydetail) as TMaster;

                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);
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
            TDetail model = SelectedMaster.AddDetailtoMaster<TDetail>();

            var result = await OnShowDialogDetails.Invoke(model);
            if (!result.Cancelled)
            {
                SelectedDetail = result.Data as TDetail;
                //TDetailGedById querydetail = new() { Id = data.Id };
                //SelectedDetail = await mediator.Send(querydetail) as TDetail;
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);

                TMasterGedById query = new() { Id = SelectedMaster.Id };

                SelectedMaster = (await mediator.Send(query)) as TMaster;

                await SelectedMasterChanged.InvokeAsync(SelectedMaster);
                await SelectedDetailChanged.InvokeAsync(SelectedDetail);


            }
        }

        async Task EditDetail()
        {
            var result = await OnShowDialogDetails.Invoke(SelectedDetail);

            if (!result.Cancelled)
            {
                SelectedDetail = result.Data as TDetail;
                //TDetailGedById querydetail = new() { Id = data.Id };
                //SelectedDetail = await mediator.Send(querydetail) as TDetail;
                ElementsMasters = (await mediator.Send(MasterList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);

                TMasterGedById query = new() { Id = SelectedMaster.Id };

                SelectedMaster = (await mediator.Send(query)) as TMaster;

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
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                TMasterGedById query = new() { Id = SelectedMaster.Id };

                SelectedMaster = (await mediator.Send(query)) as TMaster;

                await SelectedMasterChanged.InvokeAsync(SelectedMaster);

            }


        }

    }
}
