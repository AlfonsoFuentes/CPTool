using CPtool.ExtensionMethods;

namespace CPTool.NewPages.Components
{
    public partial class SimpleListComponent<TMaster, TMasterList, TDeleteMaster, TGedById>
        where TMaster : EditCommand, new()

        where TMasterList : GetListQuery, new()
        where TDeleteMaster : DeleteCommand, new()

        where TGedById : GetByIdQuery, new()
    {
        
        TMasterList ModelList { get; set; } = new();
        [Parameter]

        public List<TMaster> ElementsMasters { get; set; } = new();
        [Parameter]
        public RenderFragment MasterOtherButtons { get; set; }
        [Parameter]
        public EventCallback<List<TMaster>> ElementsMastersChanged { get; set; }
        [Parameter]
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
        [Parameter]
        public EventCallback OnAdd { get; set; }
        [Parameter]
        public EventCallback OnEdit { get; set; }
        [Parameter]
        public EventCallback OnDelete { get; set; }
        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> eq)
        {
            if (eq.Item.Id == SelectedMaster.Id) return;
           
            SelectedMaster = eq.Item;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);

        }

        async Task Add()
        {
            if (OnAdd.HasDelegate)  await OnAdd.InvokeAsync();
            else
            {
                TMaster model = new();

                var result = await OnShowDialogMaster.Invoke(model);
                if (!result.Cancelled)
                {
                    if (result.Data is TMaster)
                    {
                        var data = result.Data as TMaster;
                        TGedById querydetail = new() { Id = data.Id };
                        SelectedMaster = await Mediator.Send(querydetail) as TMaster;


                        ElementsMasters = (await Mediator.Send(ModelList)) as List<TMaster>;
                        await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                        await SelectedMasterChanged.InvokeAsync(SelectedMaster);
                    }

                }
            }
            
        }
        async Task Edit()
        {
            if (OnEdit.HasDelegate) await OnEdit.InvokeAsync();
            else
            {
                var result = await OnShowDialogMaster.Invoke(SelectedMaster);

                if (!result.Cancelled)
                {
                    if (result.Data is TMaster)
                    {
                        var data = result.Data as TMaster;
                        TGedById querydetail = new() { Id = data.Id };
                        SelectedMaster = await Mediator.Send(querydetail) as TMaster;
                        ElementsMasters = (await Mediator.Send(ModelList)) as List<TMaster>;
                        await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                        await SelectedMasterChanged.InvokeAsync(SelectedMaster);
                    }
                }
            }
        }
        async Task Delete()
        {
            if (OnDelete.HasDelegate) await OnDelete.InvokeAsync();
            else
            {
                TDeleteMaster ModelDelete = new() { Id = SelectedMaster.Id, Name = SelectedMaster.Name };

                var result = await ToolDialogService.DeleteRow(ModelDelete);

                if (!result.Cancelled)
                {
                    SelectedMaster = new();
                    ElementsMasters = (await Mediator.Send(ModelList)) as List<TMaster>;
                    await ElementsMastersChanged.InvokeAsync(ElementsMasters);
                    await SelectedMasterChanged.InvokeAsync(SelectedMaster);

                }
            }

        }

    }
}
