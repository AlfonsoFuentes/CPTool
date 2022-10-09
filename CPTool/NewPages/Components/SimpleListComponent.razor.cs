namespace CPTool.NewPages.Components
{
    public partial class SimpleListComponent<TMaster,  TMasterList, TDeleteMaster, TGedById>
        where TMaster : AddEditCommand, new()
       
        where TMasterList : GetListQuery, new()
        where TDeleteMaster : DeleteCommand, new()
      
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
            TMaster model = new();

            var result = await OnShowDialogMaster.Invoke(model);
            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
               
                ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
            }

        }

        async Task Edit()
        {

            var result = await OnShowDialogMaster.Invoke(SelectedMaster);

            if (!result.Cancelled)
            {
                ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;
                await ElementsMastersChanged.InvokeAsync(ElementsMasters);
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

            }


        }
        
    }
}
