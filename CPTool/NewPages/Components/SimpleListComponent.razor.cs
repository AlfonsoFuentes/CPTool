using CPtool.ExtensionMethods;

namespace CPTool.NewPages.Components
{
    public partial class SimpleListComponent<TMaster, TMasterList, TDeleteMaster, TGedById>
        where TMaster : EditCommand, new()

        where TMasterList : GetListQuery, new()
        where TDeleteMaster : Delete, new()

        where TGedById : GetByIdQuery, new()
    {
        [Inject]
        public IMediator mediator { get; set; }
        TMasterList ModelList { get; set; } = new();
        [Parameter]

        public List<TMaster> ElementsMasters { get; set; } = new();

        [Parameter]

        public EventCallback<List<TMaster>> ElementsMastersChanged { get; set; }
        public TMaster SelectedMaster { get; set; } = new();
        [Parameter]
        public EventCallback<TMaster> SelectedMasterChanged { get; set; }
        [Parameter]
        [EditorRequired]
        public RenderFragment MasterContextTh { get; set; }
        [Parameter]
        [EditorRequired]
        public RenderFragment<TMaster> MasterContextTd { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TMaster, Task<DialogResult>> OnShowDialogMaster { get; set; }

        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> eq)
        {
            if (eq.Item.Id == SelectedMaster.Id) return;
            TGedById getbyid = new()
            {
                Id = eq.Item.Id,
            };
            SelectedMaster = await mediator.Send(getbyid) as TMaster;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);

        }

        async Task Add()
        {
            TMaster model = new();

            var result = await OnShowDialogMaster.Invoke(model);
            if (!result.Cancelled)
            {
                var data = result.Data as TMaster;
                TGedById querydetail = new() { Id = data.Id };
                SelectedMaster = await mediator.Send(querydetail) as TMaster;


                ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);
            }
        }
        async Task Edit()
        {

            var result = await OnShowDialogMaster.Invoke(SelectedMaster);

            if (!result.Cancelled)
            {
                var data = result.Data as TMaster;
                TGedById querydetail = new() { Id = data.Id };
                SelectedMaster = await mediator.Send(querydetail) as TMaster;
                ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;
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
                ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);

            }


        }

    }
}
