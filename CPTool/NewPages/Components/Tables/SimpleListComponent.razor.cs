using CPtool.ExtensionMethods;

namespace CPTool.NewPages.Components.Tables
{
    public partial class SimpleListComponent<TMaster, TMasterList, TDeleteMaster, TGedById>
        where TMaster : EditCommand, new()

        where TMasterList : GetListQuery, new()
        where TDeleteMaster : DeleteCommand, new()

        where TGedById : GetByIdQuery, new()
    {

        [Parameter]
        [Category("Footer")]
        public RenderFragment FooterContent { get; set; }
        TMasterList MasterList { get; set; } = new();

        [Parameter]
        public RenderFragment MasterOtherButtons { get; set; }

        [Parameter]
        public List<TMaster> ElementsMasters { get; set; } = new();
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
        public Func<TMaster, Task<DialogResult>> OnShowDialogMaster { get; set; }
        [Parameter]
        public EventCallback OnAdd { get; set; }
        [Parameter]
        public EventCallback OnEdit { get; set; }
        [Parameter]
        public EventCallback OnDelete { get; set; }
        [Parameter]
        public EventCallback OnPrint { get; set; }
        [Parameter]
        public EventCallback OnExcel { get; set; }
        [Parameter]
        public EventCallback OnPDF { get; set; }
        [Parameter]
        [EditorRequired]
        public List<TMaster> ElementsMastersSelected { get; set; } = new();
        async Task RowClickedMaster(TableRowClickEventArgs<TMaster> eq)
        {
          

            SelectedMaster = eq.Item;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);

        }

        async Task Add()
        {
            if (OnAdd.HasDelegate) await OnAdd.InvokeAsync();
            else
            {
                TMaster model = new();

                var result = await OnShowDialogMaster.Invoke(model);
                if (!result.Cancelled)
                {
                    SelectedMaster = result.Data as TMaster;
                    await UpdateTables();

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
                    SelectedMaster = result.Data as TMaster;
                    await UpdateTables();
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
                    await UpdateTables();

                }
            }

        }
        async Task UpdateTables()
        {

            ElementsMasters = await Mediator.Send(MasterList) as List<TMaster>;
            await ElementsMastersChanged.InvokeAsync(ElementsMasters);
            if (SelectedMaster == null) return;
            TGedById gedById = new() { Id = SelectedMaster.Id };
            SelectedMaster = await Mediator.Send(gedById) as TMaster;
            if (SelectedMaster != null)
                await SelectedMasterChanged.InvokeAsync(SelectedMaster);


        }

    }
}
