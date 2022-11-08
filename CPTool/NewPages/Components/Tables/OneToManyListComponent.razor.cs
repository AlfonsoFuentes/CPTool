



using CPtool.ExtensionMethods;

namespace CPTool.NewPages.Components.Tables
{
    public partial class OneToManyListComponent<TMaster, TDetail, TMasterList, TDetailList, TDeleteMaster, TDeleteDetail, TMasterGedById, TDetailGedById>
        where TMaster : EditCommand, new()

        where TDetail : EditCommand, new()

        where TMasterList : GetListQuery, new()
        where TDetailList : GetListQuery, new()
        where TDeleteMaster : DeleteCommand, new()
        where TDeleteDetail : DeleteCommand, new()
        where TMasterGedById : GetByIdQuery, new()
        where TDetailGedById : GetByIdQuery, new()
    {

        [Parameter]
        [Category("Footer")]
        public RenderFragment FooterContentDetails { get; set; }
        [Parameter]
        [Category("Footer")]
        public RenderFragment FooterContentMaster { get; set; }

        TMasterList MasterList { get; set; } = new();
        TDetailList DetailList { get; set; } = new();
        [Parameter]
        public List<TMaster> ElementsMasters { get; set; } = new();
        [Parameter]
        public EventCallback<List<TMaster>> ElementsMastersChanged { get; set; }
       
        [Parameter]
        public List<TDetail> ElementsDetails { get; set; } = new();
        [Parameter]
        public EventCallback<List<TDetail>> ElementsDetailsChanged { get; set; }

        [Parameter]
        [EditorRequired]
        public List<TDetail> ElementsDetailsSelected { get; set; } = new();
        [Parameter]
        [EditorRequired]
        public List<TMaster> ElementsMastersSelected { get; set; } = new();
        [Parameter]

        public TMaster SelectedMaster { get; set; } = new();
        [Parameter]
        public EventCallback<TMaster> SelectedMasterChanged { get; set; }
        [Parameter]

        public TDetail SelectedDetail { get; set; } = new();
        [Parameter]
        public EventCallback<TDetail> SelectedDetailChanged { get; set; }
        [Parameter]
        public RenderFragment MasterOtherButtons { get; set; }
        [Parameter]
        public RenderFragment DetailsOtherButtons { get; set; }
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
            SelectedMaster = eq.Item;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);
        }
        async Task RowClickedDetail(TableRowClickEventArgs<TDetail> eq)
        {
            if (eq.Item.Id == SelectedDetail.Id) return;
            
            SelectedDetail = eq.Item;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }

        async Task Add()
        {

            TMaster model = new();
            var result = await OnShowDialogMaster.Invoke(model);
            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
                await UpdateTables();
            }
        }
       
        async Task UpdateTables()
        {
            

            ElementsDetails = await Mediator.Send(DetailList) as List<TDetail>;
            await ElementsDetailsChanged.InvokeAsync(ElementsDetails);

            ElementsMasters = await Mediator.Send(MasterList) as List<TMaster>;
            await ElementsMastersChanged.InvokeAsync(ElementsMasters);

            TMasterGedById gedById = new() { Id = SelectedMaster.Id };
            SelectedMaster = await Mediator.Send(gedById) as TMaster;
            await SelectedMasterChanged.InvokeAsync(SelectedMaster);

            TDetailGedById querydetail = new() { Id = SelectedDetail.Id };
            SelectedDetail = await Mediator.Send(querydetail) as TDetail;
            await SelectedDetailChanged.InvokeAsync(SelectedDetail);
        }

        async Task Edit()
        {

            var result = await OnShowDialogMaster.Invoke(SelectedMaster);

            if (!result.Cancelled)
            {
                SelectedMaster = result.Data as TMaster;
                await UpdateTables();
            }
        }
        async Task Delete()
        {
            TDeleteMaster ModelDelete = new() { Id = SelectedMaster.Id, Name = SelectedMaster.Name };

            var result = await ToolDialogService.DeleteRow(ModelDelete);

            if (!result.Cancelled)
            {
                SelectedMaster = new();
                await UpdateTables();

            }


        }
        async Task AddDetail()
        {
            TDetail model = SelectedMaster.AddDetailtoMaster<TDetail>();

            var result = await OnShowDialogDetails.Invoke(model);
            if (!result.Cancelled)
            {

                SelectedDetail = result.Data as TDetail;
                await UpdateTables();

                


            }
        }

        async Task EditDetail()
        {
            var result = await OnShowDialogDetails.Invoke(SelectedDetail);

            if (!result.Cancelled)
            {
                SelectedDetail = result.Data as TDetail;
                await UpdateTables();
            }
        }

        async Task DeleteDetail()
        {
            TDeleteDetail deleteDetail = new() { Id = SelectedDetail.Id, Name = SelectedDetail.Name };

            var result = await ToolDialogService.DeleteRow(deleteDetail);
            if (!result.Cancelled)
            {
                SelectedDetail = new();
              
                await UpdateTables();

            }


        }

    }
}
