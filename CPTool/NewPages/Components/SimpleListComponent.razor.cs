using CPtool.ExtensionMethods;

namespace CPTool.NewPages.Components
{
    public partial class SimpleListComponent<TMaster, TAddMaster, TMasterList, TDeleteMaster, TGedById>
        where TMaster : EditCommand, new()
       where TAddMaster : AddCommand, new()
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

        void RowClickedMaster(TableRowClickEventArgs<TMaster> eq)
        {
            SelectedMaster = eq.Item;

        }

        async Task Add()
        {
            TAddMaster addmodel = new();
            Result<int> resultaddmodel = await mediator.Send(addmodel) as Result<int>;

            if (resultaddmodel.Succeeded)
            {
                TGedById gedById = new() { Id = resultaddmodel.Data };

                var model = await mediator.Send(gedById) as TMaster;
                var result = await OnShowDialogMaster.Invoke(model);
                if (!result.Cancelled)
                {
                    SelectedMaster = result.Data as TMaster;


                    ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;
                    await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                    await SelectedMasterChanged.InvokeAsync(SelectedMaster);
                }
            }



        }

        async Task Edit()
        {

            var result = await OnShowDialogMaster.Invoke(SelectedMaster);

            if (!result.Cancelled)
            {
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
