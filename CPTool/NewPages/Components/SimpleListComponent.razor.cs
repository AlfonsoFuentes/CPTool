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
        public List<TMaster> ElementsMasters { get; set; } = new();
        public TMaster SelectedMaster { get; set; } = new();
        [Parameter]
        public RenderFragment MasterContextTh { get; set; }
        [Parameter]
        public RenderFragment<TMaster> MasterContextTd { get; set; }
        [Parameter]
        [EditorRequired]
        public Func<TMaster, Task<DialogResult>> OnShowDialogMaster { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;
        }

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

            }

        }

        async Task Edit()
        {

            var result = await OnShowDialogMaster.Invoke(SelectedMaster);

            if (!result.Cancelled)
            {
                ElementsMasters = (await mediator.Send(ModelList)) as List<TMaster>;

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
               

            }


        }
        
    }
}
